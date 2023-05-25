namespace Library_Management_System
{
    partial class UserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        // UI components
        private System.Windows.Forms.TextBox bookSearchTextBox;
        private System.Windows.Forms.DataGridView dataGridViewBooks;
        private System.Windows.Forms.Button ButtonReserveBook;
        private System.Windows.Forms.Button ButtonReturnBook;
        private System.Windows.Forms.Label userDetailsLabel;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bookSearchTextBox = new System.Windows.Forms.TextBox();
            this.dataGridViewBooks = new System.Windows.Forms.DataGridView();
            this.ButtonReserveBook = new System.Windows.Forms.Button();
            this.ButtonReturnBook = new System.Windows.Forms.Button();
            this.userDetailsLabel = new System.Windows.Forms.Label();
            this.labelLB = new System.Windows.Forms.Label();
            this.dataGridViewLibraryBook = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckoutRecord = new System.Windows.Forms.DataGridView();
            this.labelCR = new System.Windows.Forms.Label();
            this.labelBookList = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLibraryBook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCheckoutRecord)).BeginInit();
            this.SuspendLayout();
            // 
            // bookSearchTextBox
            // 
            this.bookSearchTextBox.Location = new System.Drawing.Point(20, 20);
            this.bookSearchTextBox.Name = "bookSearchTextBox";
            this.bookSearchTextBox.Size = new System.Drawing.Size(200, 20);
            this.bookSearchTextBox.TabIndex = 0;
            // 
            // dataGridViewBooks
            // 
            this.dataGridViewBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewBooks.Location = new System.Drawing.Point(20, 66);
            this.dataGridViewBooks.Name = "dataGridViewBooks";
            this.dataGridViewBooks.ReadOnly = true;
            this.dataGridViewBooks.Size = new System.Drawing.Size(595, 334);
            this.dataGridViewBooks.TabIndex = 1;
            // 
            // ButtonReserveBook
            // 
            this.ButtonReserveBook.Location = new System.Drawing.Point(20, 420);
            this.ButtonReserveBook.Name = "ButtonReserveBook";
            this.ButtonReserveBook.Size = new System.Drawing.Size(100, 30);
            this.ButtonReserveBook.TabIndex = 2;
            this.ButtonReserveBook.Text = "Reserve Book";
            this.ButtonReserveBook.Click += new System.EventHandler(this.ButtonReserveBook_Click);
            // 
            // ButtonReturnBook
            // 
            this.ButtonReturnBook.Location = new System.Drawing.Point(140, 420);
            this.ButtonReturnBook.Name = "ButtonReturnBook";
            this.ButtonReturnBook.Size = new System.Drawing.Size(100, 30);
            this.ButtonReturnBook.TabIndex = 3;
            this.ButtonReturnBook.Text = "Return Book";
            this.ButtonReturnBook.Click += new System.EventHandler(this.ButtonReturnBook_Click);
            // 
            // userDetailsLabel
            // 
            this.userDetailsLabel.Location = new System.Drawing.Point(260, 20);
            this.userDetailsLabel.Name = "userDetailsLabel";
            this.userDetailsLabel.Size = new System.Drawing.Size(242, 20);
            this.userDetailsLabel.TabIndex = 4;
            this.userDetailsLabel.Text = "User Details: ";
            // 
            // labelLB
            // 
            this.labelLB.AutoSize = true;
            this.labelLB.Location = new System.Drawing.Point(650, 50);
            this.labelLB.Name = "labelLB";
            this.labelLB.Size = new System.Drawing.Size(103, 13);
            this.labelLB.TabIndex = 7;
            this.labelLB.Text = "Checked Out Books";
            // 
            // dataGridViewLibraryBook
            // 
            this.dataGridViewLibraryBook.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewLibraryBook.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewLibraryBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLibraryBook.Location = new System.Drawing.Point(653, 66);
            this.dataGridViewLibraryBook.Name = "dataGridViewLibraryBook";
            this.dataGridViewLibraryBook.ReadOnly = true;
            this.dataGridViewLibraryBook.Size = new System.Drawing.Size(624, 142);
            this.dataGridViewLibraryBook.TabIndex = 9;
            this.dataGridViewLibraryBook.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewLibraryBook_CellFormatting);
            // 
            // dataGridViewCheckoutRecord
            // 
            this.dataGridViewCheckoutRecord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewCheckoutRecord.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCheckoutRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCheckoutRecord.Location = new System.Drawing.Point(653, 227);
            this.dataGridViewCheckoutRecord.Name = "dataGridViewCheckoutRecord";
            this.dataGridViewCheckoutRecord.ReadOnly = true;
            this.dataGridViewCheckoutRecord.Size = new System.Drawing.Size(624, 223);
            this.dataGridViewCheckoutRecord.TabIndex = 11;
            this.dataGridViewCheckoutRecord.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewCheckoutRecord_CellFormatting);
            // 
            // labelCR
            // 
            this.labelCR.AutoSize = true;
            this.labelCR.Location = new System.Drawing.Point(650, 211);
            this.labelCR.Name = "labelCR";
            this.labelCR.Size = new System.Drawing.Size(91, 13);
            this.labelCR.TabIndex = 10;
            this.labelCR.Text = "Checkout Record";
            // 
            // labelBookList
            // 
            this.labelBookList.AutoSize = true;
            this.labelBookList.Location = new System.Drawing.Point(17, 50);
            this.labelBookList.Name = "labelBookList";
            this.labelBookList.Size = new System.Drawing.Size(51, 13);
            this.labelBookList.TabIndex = 12;
            this.labelBookList.Text = "Book List";
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 476);
            this.Controls.Add(this.labelBookList);
            this.Controls.Add(this.dataGridViewCheckoutRecord);
            this.Controls.Add(this.labelCR);
            this.Controls.Add(this.dataGridViewLibraryBook);
            this.Controls.Add(this.labelLB);
            this.Controls.Add(this.bookSearchTextBox);
            this.Controls.Add(this.dataGridViewBooks);
            this.Controls.Add(this.ButtonReserveBook);
            this.Controls.Add(this.ButtonReturnBook);
            this.Controls.Add(this.userDetailsLabel);
            this.Name = "UserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Form";
            this.Load += new System.EventHandler(this.UserForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLibraryBook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCheckoutRecord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelLB;
        private System.Windows.Forms.DataGridView dataGridViewLibraryBook;
        private System.Windows.Forms.DataGridView dataGridViewCheckoutRecord;
        private System.Windows.Forms.Label labelCR;
        private System.Windows.Forms.Label labelBookList;
    }
}