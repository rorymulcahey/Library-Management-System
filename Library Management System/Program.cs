using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //DatabaseHelper.InitializeDatabase();
            //DatabaseHelper.AddSampleUsers();
            //DatabaseHelper.AddSampleBooksFromCsv(@"..\..\Files\books.csv");

            using (LoginForm loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    User loggedInUser = loginForm.LoggedInUser;
                    Form userForm = new UserForm(loggedInUser);
                    Application.Run(userForm);
                }

            }
        }
    }
}
