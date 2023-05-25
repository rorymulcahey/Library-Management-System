using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class LibraryBookController
    {
        private LibraryBookManager _libraryBookManager;

        public LibraryBookController(LibraryBookManager libraryBookManager)
        {
            _libraryBookManager = libraryBookManager;
        }

        public void ReserveBook(Book book)
        {
            _libraryBookManager.ReserveBook(book);
        }

        public void ReturnBook(Book book)
        {
            _libraryBookManager.ReturnBook(book);
        }
    }

}
