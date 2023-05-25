using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
    }

    public class MockUserRepository : IUserRepository
    {
        public IEnumerable<User> GetAllUsers()
        {
            return new List<User>
            {
                new RegularUser(0, "Regular User", "regular@ex.com"),
                new PremiumUser(0, "Premium User", "premium@ex.com"),
                new LibrarianUser(0, "Admin", "admin@ex.com")
            };
        }
    }

    public class SQLiteUserRepository : IUserRepository
    {
        private string connectionString = @"Data Source=..\..\Files\LibraryManagementSystem.db;Version=3;";

        public IEnumerable<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = @"
                                SELECT ID, NAME, EMAIL, USER_TYPE
                                FROM USERS;
                                ";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal("ID"));
                            string name = reader.GetString(reader.GetOrdinal("NAME"));
                            string email = reader.GetString(reader.GetOrdinal("EMAIL"));
                            string userType = reader.GetString(reader.GetOrdinal("USER_TYPE"));

                            User user = null;
                            switch (userType)
                            {
                                case "PremiumUser":
                                    user = new PremiumUser(id, name, email);
                                    break;
                                case "LibrarianUser":
                                    user = new LibrarianUser(id, name, email);
                                    break;
                                default:
                                    user = new RegularUser(id, name, email);
                                    break;
                            }
                            
                            users.Add(user);
                        }
                    }
                }
            }

            return users;
        }
    }
}
