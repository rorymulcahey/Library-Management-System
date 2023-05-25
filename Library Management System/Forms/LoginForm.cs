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
    public partial class LoginForm : Form
    {
        private readonly UserService _userService;

        public LoginForm()
        {
            InitializeComponent();
            _userService = new UserService(new SQLiteUserRepository());
            comboBoxUser.DataSource = _userService.GetAllUsers();
            comboBoxUser.DisplayMember = "Name";
            comboBoxUser.ValueMember = "Id";
        }
        
        public User LoggedInUser { get; private set; }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            User selectedUser = comboBoxUser.SelectedItem as User;
            if (selectedUser == null)
            {
                MessageBox.Show("Please select a user.");
            }
            else
            {
                LoggedInUser = selectedUser;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
