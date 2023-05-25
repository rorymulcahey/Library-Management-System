using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class UserForm : Form
    {
        private User _user;
        private LibraryBookManager _libraryBookManager;
        private BindingSource _booksBindingSource = new BindingSource();
        private BindingSource _libraryBooksBindingSource = new BindingSource();
        private BindingSource _checkoutRecordsBindingSource = new BindingSource();

        public UserForm(User LoggedInUser)
        {
            InitializeComponent();
            _user = LoggedInUser;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            _libraryBookManager = new LibraryBookManager(_user, new SQLiteBookRepository());

            _booksBindingSource.DataSource = _libraryBookManager.Books;
            _libraryBooksBindingSource.DataSource = _libraryBookManager.LibraryBooks;
            _checkoutRecordsBindingSource.DataSource = _libraryBookManager.CheckoutRecords;

            dataGridViewBooks.DataSource = _booksBindingSource;
            dataGridViewLibraryBook.DataSource = _libraryBooksBindingSource;
            dataGridViewCheckoutRecord.DataSource = _checkoutRecordsBindingSource;
        }

        private void ButtonReserveBook_Click(object sender, EventArgs e)
        {            
            if (dataGridViewBooks.CurrentRow != null)
            {
                _libraryBookManager.ReserveBook((Book)dataGridViewBooks.CurrentRow.DataBoundItem);
                RefreshGridViews();
            }
        }

        private void ButtonReturnBook_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.CurrentRow != null)
            {
                _libraryBookManager.ReturnBook((Book)dataGridViewBooks.CurrentRow.DataBoundItem);
                RefreshGridViews();
            }
        }

        private void RefreshGridViews()
        {
            _booksBindingSource.DataSource = _libraryBookManager.Books;
            _libraryBooksBindingSource.DataSource = _libraryBookManager.LibraryBooks;
            _checkoutRecordsBindingSource.DataSource = _libraryBookManager.CheckoutRecords;

            _booksBindingSource.ResetBindings(true);
            _checkoutRecordsBindingSource.ResetBindings(true);
            _libraryBooksBindingSource.ResetBindings(true);
        }

        // converts book column from Book class into object book title
        private void dataGridViewLibraryBook_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewColumn column = dataGridViewLibraryBook.Columns[e.ColumnIndex];
            if (column.DataPropertyName == "Book")
            {
                LibraryBook libraryBook = dataGridViewLibraryBook.Rows[e.RowIndex].DataBoundItem as LibraryBook;
                if (libraryBook != null && libraryBook.Book != null)
                {
                    e.Value = libraryBook.Book.Title;
                    e.FormattingApplied = true;
                }
            }
        }

        // converts book column from LibraryBook class into object book title
        private void dataGridViewCheckoutRecord_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewColumn column = dataGridViewCheckoutRecord.Columns[e.ColumnIndex];
            if (column.DataPropertyName == "LibraryBook")
            {
                CheckoutRecord checkoutRecord = dataGridViewCheckoutRecord.Rows[e.RowIndex].DataBoundItem as CheckoutRecord;
                if (checkoutRecord != null && checkoutRecord.LibraryBook != null && checkoutRecord.LibraryBook.Book != null)
                {
                    e.Value = checkoutRecord.LibraryBook.Book.Title;
                    e.FormattingApplied = true;
                }
            }
            else if (column.DataPropertyName == "User")
            {
                CheckoutRecord checkoutRecord = dataGridViewCheckoutRecord.Rows[e.RowIndex].DataBoundItem as CheckoutRecord;
                if (checkoutRecord != null && checkoutRecord.User != null)
                {
                    e.Value = checkoutRecord.User.Name; 
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
