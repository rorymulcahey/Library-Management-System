using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library_Management_System
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks();
        int GetCheckedOutBooksCount(User user);
        IEnumerable<CheckoutRecord> GetCheckoutRecordsForUser(User user, List<Book> books);
        IEnumerable<LibraryBook> GetLibraryBooksForUser(User user, List<Book> books, List<CheckoutRecord> checkoutRecords);
        CheckoutRecord ReserveBookAndGetCheckoutRecord(Book book, User user);
        bool ReturnBook(CheckoutRecord checkoutRecord, DateTime returnDate);
    }

    public class MockBookRepository : IBookRepository
    {
        public IEnumerable<Book> GetAllBooks()
        {
            return new List<Book>()
            {
                new Book(0, "Test1", "Test2", Genre.Fiction),
                new Book(-1, "Test3", "Test4", Genre.NonFiction),
                new Book(-2, "Test5", "Test6", Genre.ScienceFiction)
            };
        }

        public int GetCheckedOutBooksCount(User user) { return 0; }

        public IEnumerable<LibraryBook> GetLibraryBooksForUser(User user, List<Book> books, List<CheckoutRecord> checkoutRecords)
        {
            if (user.IsLibrarian)
            {
                return GetAllLibraryBooks(books);
            }
            else
            {
                List<LibraryBook> libraryBooks = new List<LibraryBook>();

                foreach (CheckoutRecord cr in checkoutRecords)
                {
                    if (cr.ReturnDate == null) // The book hasn't been returned yet
                    {
                        LibraryBook lb = cr.LibraryBook;
                        libraryBooks.Add(lb);
                    }
                }

                return libraryBooks;
            }
        }

        public IEnumerable<LibraryBook> GetAllLibraryBooks(List<Book> books)
        {
            return new List<LibraryBook>()
            {
                new LibraryBook(0, books[0], -1, false),
                new LibraryBook(-1, books[0], -2, false),
                new LibraryBook(-2, books[1], -1, false),
                new LibraryBook(-3, books[1], -2, false),
                new LibraryBook(-4, books[2], -1, false),
                new LibraryBook(-5, books[2], -2, false)
            };
        }

        public IEnumerable<CheckoutRecord> GetCheckoutRecordsForUser(User user, List<Book> books)
        { return new List<CheckoutRecord>(); }

        public CheckoutRecord ReserveBookAndGetCheckoutRecord(Book book, User user)
        {
            return new CheckoutRecord(0, user, new LibraryBook(0, book, -1, false), DateTime.Now, DateTime.Now);
        }

        public bool ReturnBook(CheckoutRecord checkoutRecord, DateTime returnDate) { checkoutRecord.ReturnDate = returnDate; return true; }
    }

    public class SQLiteBookRepository : IBookRepository
    {
        private string _connectionString = @"Data Source=..\..\Files\LibraryManagementSystem.db;Version=3;";   

        public IEnumerable<Book> GetAllBooks() {
            List<Book> books = new List<Book>();

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM BOOKS";

                using(SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using(SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal("Id"));
                            string title = reader.GetString(reader.GetOrdinal("Title"));
                            string author = reader.GetString(reader.GetOrdinal("Author"));
                            string genreString = reader.GetString(reader.GetOrdinal("Genre"));
                            if (Enum.TryParse(genreString, true, out Genre genre))
                            {
                                books.Add(new Book(id, title, author, genre));
                            }
                            else
                            {
                                books.Add(new Book(id, title, author, null));
                            }
                        }
                    }
                }
            }

            return books;
        }

        public int GetCheckedOutBooksCount(User user)
        {
            int count;

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT COUNT(*)
                    FROM CheckoutRecords
                    WHERE UserId = @UserId AND ReturnDate IS NULL;
                ";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", user.Id);

                    count = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            return count;
        }

        public IEnumerable<LibraryBook> GetLibraryBooksForUser(User user, List<Book> books, List<CheckoutRecord> checkoutRecords)
        {
            if (user.IsLibrarian)
            {
                return GetAllLibraryBooks(books);
            }
            else
            {
                List<LibraryBook> libraryBooks = new List<LibraryBook>();

                foreach (CheckoutRecord cr in checkoutRecords)
                {
                    if (cr.ReturnDate == null) // The book hasn't been returned yet
                    {
                        LibraryBook lb = cr.LibraryBook;
                        libraryBooks.Add(lb);                        
                    }
                }

                return libraryBooks;
            }
        }

        private IEnumerable<LibraryBook> GetAllLibraryBooks(List<Book> books)
        {
            List<LibraryBook> libraryBooks = new List<LibraryBook>();

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query = @"
                                SELECT lb.Id as LibraryBookId, lb.CopyNumber, lb.IsAvailable, lb.BookId
                                FROM LibraryBooks lb;";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int libraryBookId = reader.GetInt32(reader.GetOrdinal("LibraryBookId"));
                            int copyNumber = reader.GetInt32(reader.GetOrdinal("CopyNumber"));
                            bool isAvailable = reader.GetBoolean(reader.GetOrdinal("IsAvailable"));
                            int bookId = reader.GetInt32(reader.GetOrdinal("BookId"));

                            Book book = books.FirstOrDefault(b => b.Id == bookId);

                            LibraryBook libraryBook = new LibraryBook(libraryBookId, book, copyNumber, isAvailable);
                            libraryBooks.Add(libraryBook);
                        }
                    }
                }
            }

            return libraryBooks;
        }

        public IEnumerable<CheckoutRecord> GetCheckoutRecordsForUser(User user, List<Book> books)
        {
            List<CheckoutRecord> checkoutRecords = new List<CheckoutRecord>();

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                string query;

                if (user.IsLibrarian)
                {
                    query = @"
                                    SELECT cr.Id as CheckoutRecordId, cr.UserId, cr.CheckoutDate, cr.DueDate, cr.ReturnDate,
                                           lb.Id as LibraryBookId, lb.CopyNumber, lb.IsAvailable,
                                           lb.BookId
                                    FROM CheckoutRecords cr
                                    JOIN LibraryBooks lb ON cr.LibraryBookId = lb.Id;";
                }
                else
                {
                    query = @"
                                    SELECT cr.Id as CheckoutRecordId, cr.CheckoutDate, cr.DueDate, cr.ReturnDate,
                                           lb.Id as LibraryBookId, lb.CopyNumber, lb.IsAvailable,
                                           lb.BookId
                                    FROM CheckoutRecords cr
                                    JOIN LibraryBooks lb ON cr.LibraryBookId = lb.Id
                                    WHERE cr.UserId = @UserId;";
                }


                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    if (!user.IsLibrarian)
                    {
                        command.Parameters.AddWithValue("@UserId", user.Id);
                    }

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int checkoutRecordId = reader.GetInt32(reader.GetOrdinal("CheckoutRecordId"));
                            DateTime checkoutDate = reader.GetDateTime(reader.GetOrdinal("CheckoutDate"));
                            DateTime dueDate = reader.GetDateTime(reader.GetOrdinal("DueDate"));
                            DateTime? returnDate = reader.IsDBNull(reader.GetOrdinal("ReturnDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("ReturnDate"));

                            int libraryBookId = reader.GetInt32(reader.GetOrdinal("LibraryBookId"));
                            int copyNumber = reader.GetInt32(reader.GetOrdinal("CopyNumber"));
                            bool isAvailable = reader.GetBoolean(reader.GetOrdinal("IsAvailable"));

                            int bookId = reader.GetInt32(reader.GetOrdinal("BookId"));
                            Book book = books.FirstOrDefault(b => b.Id == bookId);

                            LibraryBook libraryBook = new LibraryBook(libraryBookId, book, copyNumber, isAvailable);
                            CheckoutRecord checkoutRecord = new CheckoutRecord(checkoutRecordId, user, libraryBook, checkoutDate, dueDate, returnDate);

                            checkoutRecords.Add(checkoutRecord);

                        }
                    }
                }
            }

            return checkoutRecords;
        }

        public CheckoutRecord ReserveBookAndGetCheckoutRecord(Book book, User user)
        {
            LibraryBook libraryBook = null;
            CheckoutRecord checkoutRecord = null;

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try { 
                        // Find the first available library book for the given book ID
                        string findAvailableLibraryBookQuery = @"
													    SELECT Id, CopyNumber
													    FROM LibraryBooks
													    WHERE BookId = @BookId AND IsAvailable = 1
													    LIMIT 1;
													    ";
                        using (SQLiteCommand command = new SQLiteCommand(findAvailableLibraryBookQuery, connection))
                        {
                            command.Parameters.AddWithValue("@BookId", book.Id);
                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    int libraryBookId = reader.GetInt32(reader.GetOrdinal("Id"));
                                    int copyNumber = reader.GetInt32(reader.GetOrdinal("CopyNumber"));

                                    // Update the LibraryBook table to set IsAvailable to false
                                    string updateLibraryBookQuery = @"
														    UPDATE LibraryBooks
														    SET IsAvailable = 0
														    WHERE Id = @LibraryBookId;
														    ";
                                    using (SQLiteCommand updateCommand = new SQLiteCommand(updateLibraryBookQuery, connection))
                                    {
                                        updateCommand.Parameters.AddWithValue("@LibraryBookId", libraryBookId);
                                        updateCommand.ExecuteNonQuery();
                                    }

                                    libraryBook = new LibraryBook(libraryBookId, book, copyNumber, false);
                                }
                            }
                        }

                        if (libraryBook != null)
                        {
                            DateTime checkoutDate = DateTime.Now;
                            DateTime dueDate = DateTime.Now.AddDays(7);

                            // Insert the record into the CheckoutRecords table
                            string insertCheckoutRecordQuery = @"
													    INSERT INTO CheckoutRecords (UserId, LibraryBookId, CheckoutDate, DueDate)
													    VALUES (@UserId, @LibraryBookId, @CheckoutDate, @DueDate);
													    SELECT last_insert_rowid();
													    ";
                            using (SQLiteCommand command = new SQLiteCommand(insertCheckoutRecordQuery, connection))
                            {
                                command.Parameters.AddWithValue("@UserId", user.Id);
                                command.Parameters.AddWithValue("@LibraryBookId", libraryBook.Id);
                                command.Parameters.AddWithValue("@CheckoutDate", checkoutDate);
                                command.Parameters.AddWithValue("@DueDate", dueDate);

                                int checkoutRecordId = (int)(long)command.ExecuteScalar();
                                checkoutRecord = new CheckoutRecord(checkoutRecordId, user, libraryBook, checkoutDate, dueDate);
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Database error
                    }
                }                
            }

            return checkoutRecord;
        }

        public bool ReturnBook(CheckoutRecord checkoutRecord, DateTime returnDate)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try { 
                        string updateCheckoutRecordQuery = @"
			                                                UPDATE CheckoutRecords
			                                                SET ReturnDate = @ReturnDate
			                                                WHERE Id = @Id;
		                                                ";
                        using (SQLiteCommand command = new SQLiteCommand(updateCheckoutRecordQuery, connection))
                        {
                            command.Parameters.AddWithValue("@Id", checkoutRecord.Id);
                            command.Parameters.AddWithValue("@ReturnDate", returnDate);

                            command.ExecuteNonQuery();
                        }

                        string updateLibraryBookQuery = @"
			                                            UPDATE LibraryBooks
			                                            SET IsAvailable = 1
			                                            WHERE Id = @LibraryBookId;
		                                            ";
                        using (SQLiteCommand command = new SQLiteCommand(updateLibraryBookQuery, connection))
                        {
                            command.Parameters.AddWithValue("@LibraryBookId", checkoutRecord.LibraryBook.Id);

                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}



