using System.Data.SQLite;
using System.IO;

public static class DatabaseHelper
{
    private static string connectionString = @"Data Source=..\..\Files\LibraryManagementSystem.db;Version=3;";

    public static void InitializeDatabase()
    {
        if (!File.Exists(@"..\..\Files\LibraryManagementSystem.db"))
        {
            SQLiteConnection.CreateFile(@"..\..\Files\LibraryManagementSystem.db");

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Create tables for your data
                string createBooksTableQuery = @"
                    CREATE TABLE IF NOT EXISTS books (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        title TEXT NOT NULL,
                        author TEXT NOT NULL,
                        genre TEXT NOT NULL
                    );";

                string createUsersTableQuery = @"
                    CREATE TABLE IF NOT EXISTS users (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        name TEXT NOT NULL,
                        email TEXT UNIQUE NOT NULL,
                        password TEXT NOT NULL,
                        user_type TEXT NOT NULL
                    );";

                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = createBooksTableQuery;
                    command.ExecuteNonQuery();

                    command.CommandText = createUsersTableQuery;
                    command.ExecuteNonQuery();
                }
            }
        }        
    }

    public static void AddSampleUsers()
    {
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            string[] userNames = {
            "Alan Turing",
            "Linus Torvalds",
            "Steve Jobs",
            "Edsger Dijkstra",
            "Bill Gates"
        };
            string[] userEmails = {
            "alan.turing@example.com",
            "linus.torvalds@example.com",
            "steve.jobs@example.com",
            "edsger.dijkstra@example.com",
            "bill.gates@example.com"
        };
            string[] userPasswords = {
            "password1",
            "password2",
            "password3",
            "password4",
            "password5"
        };
            string[] userTypes = {
            "RegularUser",
            "PremiumUser",
            "RegularUser",
            "RegularUser",
            "PremiumUser"
        };

            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                for (int i = 0; i < userNames.Length; i++)
                {
                    command.CommandText = 
                        @"INSERT INTO users (name, email, password, user_type)
                        VALUES (@name, @email, @password, @user_type);";
                    command.Parameters.AddWithValue("@name", userNames[i]);
                    command.Parameters.AddWithValue("@email", userEmails[i]);
                    command.Parameters.AddWithValue("@password", userPasswords[i]);
                    command.Parameters.AddWithValue("@user_type", userTypes[i]);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }            
        }
    }

    public static void AddSampleBooksFromCsv(string csvPath)
    {
        if (File.Exists(csvPath))
        {
            string[] lines = File.ReadAllLines(csvPath);

            using (SQLiteConnection connection = new SQLiteConnection(connectionString)) { 
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    bool firstRow = true;
                    foreach (string line in lines)
                    {
                        if (firstRow)
                        {
                            firstRow = false;
                            continue; // Skip the header line
                        }

                        string[] values = line.Split(',');
                        string title = values[0];
                        string author = values[1];
                        string genre = values[2];

                        command.CommandText = "INSERT INTO books (title, author, genre) VALUES (@title, @author, @genre);";
                        command.Parameters.AddWithValue("@title", title);
                        command.Parameters.AddWithValue("@author", author);
                        command.Parameters.AddWithValue("@genre", genre);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }
        else
        {
            System.Console.WriteLine($"CSV file not found at {csvPath}");
        }
    }
}