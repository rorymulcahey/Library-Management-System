using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public abstract class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        protected int _numberOfCheckedOutBooks = 0;


        public User (int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public void UpdateCheckedOutBooksCount(int count)
        {
            _numberOfCheckedOutBooks = count;
        }

        public virtual bool IsLibrarian
        {
            get { return false; }
        }

        public abstract bool CanBorrowBook();

        public virtual void OnBookReserved()
        {
            _numberOfCheckedOutBooks++;
        }

        public virtual void OnBookReturned()
        {
            _numberOfCheckedOutBooks--;
        }
    }

    public class LibrarianUser : User
    {
        public LibrarianUser(int id, string name, string email) : base(id, name, email) { }

        public override bool IsLibrarian
        {
            get { return true; }
        }

        public override bool CanBorrowBook()
        {
            return true;
        }
    }

    public class RegularUser : User
    {
        public RegularUser(int id, string name, string email) : base(id, name, email) { }

        public override bool CanBorrowBook()
        {
            if (_numberOfCheckedOutBooks >= 1) { return false; }
            else { return true; }
        }
    }

    public class PremiumUser : User
    {
        public PremiumUser(int id, string name, string email) : base(id, name, email) { }

        public override bool CanBorrowBook()
        {
            if (_numberOfCheckedOutBooks >= 5) { return false; }
            else { return true; }
        }
    }
}
