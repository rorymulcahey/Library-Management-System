using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    /*
     Maintains and stores all check-out and check-in details of a book
    */
    public class CheckoutRecord
    {
        [Browsable(false)]
        public int Id { get; set; }
        [Browsable(false)]
        public User User { get; set; }
        public LibraryBook LibraryBook { get; set; }
        public DateTime CheckoutDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public CheckoutRecord() { }

        public CheckoutRecord(int id, User user, LibraryBook libraryBook, DateTime checkoutDate, DateTime dueDate)
        {
            Id = id;
            User = user;
            LibraryBook = libraryBook;
            CheckoutDate = checkoutDate;
            DueDate = dueDate;
            ReturnDate = null;
        }

        public CheckoutRecord(int id, User user, LibraryBook libraryBook, DateTime checkoutDate, DateTime dueDate, DateTime? returnDate)
        {
            Id = id;
            User = user;
            LibraryBook = libraryBook;
            CheckoutDate = checkoutDate;
            DueDate = dueDate;
            ReturnDate = returnDate;
        }

        public void ReturnCheckout(DateTime returnDate)
        {
            ReturnDate = returnDate;
        }
    }
}
