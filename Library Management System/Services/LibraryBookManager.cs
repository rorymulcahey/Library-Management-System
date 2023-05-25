using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    class LibraryBookManager
    {
        private List<Book> _books;
        private List<CheckoutRecord> _checkoutRecords;
        private readonly IBookRepository _bookRepository;
        private readonly User _user;

        public LibraryBookManager(User user, IBookRepository bookRepository)
        {
            _user = user;
            _bookRepository = bookRepository;
            UpdateCheckedOutBooksCount();
        }

        private void UpdateCheckedOutBooksCount()
        {
            int count = _bookRepository.GetCheckedOutBooksCount(_user);
            _user.UpdateCheckedOutBooksCount(count);
        }

        public List<Book> Books
        {
            get
            {
                if (_books == null)
                {
                    _books = _bookRepository.GetAllBooks().ToList();
                }
                return _books;
            }
        }

        public List<LibraryBook> LibraryBooks
        {
            get
            {
                if (_checkoutRecords == null)
                {
                    _checkoutRecords = _bookRepository.GetCheckoutRecordsForUser(_user, _books).ToList();
                }
                return _bookRepository.GetLibraryBooksForUser(_user, _books, _checkoutRecords).ToList();
            }
        }

        public List<CheckoutRecord> CheckoutRecords
        {
            get
            {
                if (_checkoutRecords == null)
                {
                    _checkoutRecords = _bookRepository.GetCheckoutRecordsForUser(_user, _books).ToList();
                }
                return _checkoutRecords;
            }
        }

        public void ReserveBook(Book book)
        {
            if (_checkoutRecords.Any(cr => cr.LibraryBook.Book.Id == book.Id && cr.User.Id == _user.Id && cr.ReturnDate == null))
            {
                // Already checked out this book
                return;
            }
            else if (!_user.CanBorrowBook())
            {
                // Reached borrowing limit
                return;
            }
            else
            {
                // good to reserve!

                CheckoutRecord checkoutRecord = _bookRepository.ReserveBookAndGetCheckoutRecord(book, _user);
                if (checkoutRecord != null)
                {
                    _checkoutRecords.Add(checkoutRecord);
                    _user.OnBookReserved();
                }
                else
                {
                    // error with database
                }
            }
        }

        public void ReturnBook(Book book)
        {
            DateTime returnDate = DateTime.Now;
            CheckoutRecord checkoutRecord = GetCheckoutRecordForBook(book);
            if (checkoutRecord == null)
            {
                // Checked out book not found
                return;
            }
            else
            {
                // good for return!

                bool succesfulTransaction = _bookRepository.ReturnBook(checkoutRecord, returnDate);
                if (succesfulTransaction)
                {
                    checkoutRecord.ReturnDate = returnDate;
                    _user.OnBookReturned();
                }
                else
                {
                    // error with database
                }
            }
        }

        public CheckoutRecord GetCheckoutRecordForBook(Book book)
        {
            return _checkoutRecords.FirstOrDefault(cr => cr.LibraryBook.Book.Id == book.Id && cr.User.Id == _user.Id && cr.ReturnDate == null);
        }
    }
}
