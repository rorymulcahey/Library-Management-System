namespace Library_Management_System
{
    partial class LibrarianForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // UI components
        private System.Windows.Forms.DataGridView booksDataGridView;
        private System.Windows.Forms.TextBox bookTitleTextBox;
        private System.Windows.Forms.TextBox bookAuthorTextBox;
        private System.Windows.Forms.ComboBox bookGenreComboBox;
        private System.Windows.Forms.Button addBookButton;
        private System.Windows.Forms.Button removeBookButton;
        private System.Windows.Forms.Button updateBookButton;
        private System.Windows.Forms.TextBox userSearchTextBox;
        private System.Windows.Forms.DataGridView usersDataGridView;
        private System.Windows.Forms.Button addUserButton;
        private System.Windows.Forms.Button removeUserButton;
        private System.Windows.Forms.Button updateUserButton;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.booksDataGridView = new System.Windows.Forms.DataGridView();
            this.bookTitleTextBox = new System.Windows.Forms.TextBox();
            this.bookAuthorTextBox = new System.Windows.Forms.TextBox();
            this.bookGenreComboBox = new System.Windows.Forms.ComboBox();
            this.addBookButton = new System.Windows.Forms.Button();
            this.removeBookButton = new System.Windows.Forms.Button();
            this.updateBookButton = new System.Windows.Forms.Button();
            this.userSearchTextBox = new System.Windows.Forms.TextBox();
            this.usersDataGridView = new System.Windows.Forms.DataGridView();
            this.addUserButton = new System.Windows.Forms.Button();
            this.removeUserButton = new System.Windows.Forms.Button();
            this.updateUserButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.booksDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // booksDataGridView
            // 
            this.booksDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.booksDataGridView.Location = new System.Drawing.Point(20, 20);
            this.booksDataGridView.Name = "booksDataGridView";
            this.booksDataGridView.Size = new System.Drawing.Size(420, 200);
            this.booksDataGridView.TabIndex = 0;
            // 
            // bookTitleTextBox
            // 
            this.bookTitleTextBox.Location = new System.Drawing.Point(20, 240);
            this.bookTitleTextBox.Name = "bookTitleTextBox";
            this.bookTitleTextBox.Size = new System.Drawing.Size(150, 20);
            this.bookTitleTextBox.TabIndex = 1;
            // 
            // bookAuthorTextBox
            // 
            this.bookAuthorTextBox.Location = new System.Drawing.Point(180, 240);
            this.bookAuthorTextBox.Name = "bookAuthorTextBox";
            this.bookAuthorTextBox.Size = new System.Drawing.Size(150, 20);
            this.bookAuthorTextBox.TabIndex = 2;
            // 
            // bookGenreComboBox
            // 
            this.bookGenreComboBox.Location = new System.Drawing.Point(340, 240);
            this.bookGenreComboBox.Name = "bookGenreComboBox";
            this.bookGenreComboBox.Size = new System.Drawing.Size(100, 21);
            this.bookGenreComboBox.TabIndex = 3;
            // 
            // addBookButton
            // 
            this.addBookButton.Location = new System.Drawing.Point(20, 280);
            this.addBookButton.Name = "addBookButton";
            this.addBookButton.Size = new System.Drawing.Size(75, 23);
            this.addBookButton.TabIndex = 4;
            this.addBookButton.Text = "Add Book";
            // 
            // removeBookButton
            // 
            this.removeBookButton.Location = new System.Drawing.Point(105, 280);
            this.removeBookButton.Name = "removeBookButton";
            this.removeBookButton.Size = new System.Drawing.Size(75, 23);
            this.removeBookButton.TabIndex = 5;
            this.removeBookButton.Text = "Remove Book";
            // 
            // updateBookButton
            // 
            this.updateBookButton.Location = new System.Drawing.Point(190, 280);
            this.updateBookButton.Name = "updateBookButton";
            this.updateBookButton.Size = new System.Drawing.Size(75, 23);
            this.updateBookButton.TabIndex = 6;
            this.updateBookButton.Text = "Update Book";
            // 
            // userSearchTextBox
            // 
            this.userSearchTextBox.Location = new System.Drawing.Point(20, 320);
            this.userSearchTextBox.Name = "userSearchTextBox";
            this.userSearchTextBox.Size = new System.Drawing.Size(200, 20);
            this.userSearchTextBox.TabIndex = 7;
            // 
            // usersDataGridView
            // 
            this.usersDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.usersDataGridView.Location = new System.Drawing.Point(20, 350);
            this.usersDataGridView.Name = "usersDataGridView";
            this.usersDataGridView.Size = new System.Drawing.Size(420, 200);
            this.usersDataGridView.TabIndex = 8;
            // 
            // addUserButton
            // 
            this.addUserButton.Location = new System.Drawing.Point(20, 560);
            this.addUserButton.Name = "addUserButton";
            this.addUserButton.Size = new System.Drawing.Size(75, 23);
            this.addUserButton.TabIndex = 9;
            this.addUserButton.Text = "Add User";
            // 
            // removeUserButton
            // 
            this.removeUserButton.Location = new System.Drawing.Point(105, 560);
            this.removeUserButton.Name = "removeUserButton";
            this.removeUserButton.Size = new System.Drawing.Size(75, 23);
            this.removeUserButton.TabIndex = 10;
            this.removeUserButton.Text = "Remove User";
            // 
            // updateUserButton
            // 
            this.updateUserButton.Location = new System.Drawing.Point(190, 560);
            this.updateUserButton.Name = "updateUserButton";
            this.updateUserButton.Size = new System.Drawing.Size(75, 23);
            this.updateUserButton.TabIndex = 11;
            this.updateUserButton.Text = "Update User";
            // 
            // LibrarianForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 601);
            this.Controls.Add(this.booksDataGridView);
            this.Controls.Add(this.bookTitleTextBox);
            this.Controls.Add(this.bookAuthorTextBox);
            this.Controls.Add(this.bookGenreComboBox);
            this.Controls.Add(this.addBookButton);
            this.Controls.Add(this.removeBookButton);
            this.Controls.Add(this.updateBookButton);
            this.Controls.Add(this.userSearchTextBox);
            this.Controls.Add(this.usersDataGridView);
            this.Controls.Add(this.addUserButton);
            this.Controls.Add(this.removeUserButton);
            this.Controls.Add(this.updateUserButton);
            this.MinimumSize = new System.Drawing.Size(460, 640);
            this.Name = "LibrarianForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Librarian Form";
            ((System.ComponentModel.ISupportInitialize)(this.booksDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}

