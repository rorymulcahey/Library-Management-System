using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    /*
     Maintains the information about individual physical copies of books within the library 
    */
    public class LibraryBook
    {
        [Browsable(false)]
        public int Id { get; set; }
        public int CopyNumber { get; } // same book but different physical copy
        public bool IsAvailable { get; set; } // physical copy is currently in stock or checked out
        public Book Book { get; set; }

        public LibraryBook(int id, Book book, int copyNumber, bool isAvailable)
        {
            Id = id;
            Book = book;
            CopyNumber = copyNumber;
            IsAvailable = isAvailable;
        }
    }
}
