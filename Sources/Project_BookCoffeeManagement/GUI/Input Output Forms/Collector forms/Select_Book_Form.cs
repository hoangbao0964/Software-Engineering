using Project_BookCoffeeManagement.BLL;
﻿using Project_BookCoffeeManagement.BLL.Books;
using Project_BookCoffeeManagement.Entities.Books;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_BookCoffeeManagement.GUI.Input_Output_Forms
{
    public partial class Select_Book_Form : FormTemplate_SelectionCollector
    {
        protected BookManager bkManager;
        protected List<Book> availableBooks;
        public List<Book> selectedBooks;
        public Select_Book_Form()
        {
            InitializeComponent();
            LoadHeaderName();
            bkManager = new BookManager();
            selectedBooks = new List<Book>();
            availableBooks = new List<Book>();
            LoadDataToScreen();
        }

        protected override void LoadDataToScreen()
        {
            availableBooks = bkManager.GetAvailableBooks();
            dataGridView_AvailableItems.DataSource = availableBooks;
        }

        protected override void bunifuTileButton_AddToSelectedList_Click(object sender, EventArgs e)
        {
            Book temp = GetSelectedItemInAvailableDataGridView<Book>();
            if (temp != null)
            {
                selectedBooks.Add(temp);
                availableBooks.Remove(temp);
                Update();
            }       
        }

        protected override void bunifuTileButton_RemoveToSelectedList_Click(object sender, EventArgs e)
        {
            Book temp = GetSelectedItemInSelectedDataGridView<Book>();
            if (temp != null)
            {
                selectedBooks.Remove(temp);
                availableBooks.Add(temp);
                Update();
            }
        }

        private void Update()
        {
            dataGridView_SelectedItems.DataSource = null;
            dataGridView_AvailableItems.DataSource = null;
            dataGridView_SelectedItems.DataSource = selectedBooks;
            dataGridView_AvailableItems.DataSource = availableBooks;
        }

        protected override void dataGridView_AvailableItems_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CallBookForm(GetSelectedItemInAvailableDataGridView<Book>());
        }

        private void CallBookForm(Book book)
        {
            Form CallForm = new BookForm("View", book);
            CallForm.ShowDialog();
        }

        protected override void dataGridView_SelectedItems_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CallBookForm(GetSelectedItemInAvailableDataGridView<Book>());
        }
        
        protected override void Filter(string keyword)
        {
            List<Book> res =  bkManager.Filter(keyword, availableBooks);
            dataGridView_AvailableItems.DataSource = res;
        }

    }
}
