using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public enum Genre
    {
        Fiction,
        NonFiction,
        ScienceFiction,
        Fantasy,
        Mystery,
        Biography,
        History
    }

    public class Book
    {    
        /*
         Maintains the general information about all available books
        */
        [Browsable(false)]
        public int Id { get; }
        public string Title { get; set; }
        public string Author { get; set; }
        public Genre? BookGenre { get; set; }

        public Book()
        {
            
        }

        public Book(int id, string title, string author, Genre? genre)
        {
            Id = id;
            Title = title;
            Author = author;
            BookGenre = genre;            
        }
    }

}
