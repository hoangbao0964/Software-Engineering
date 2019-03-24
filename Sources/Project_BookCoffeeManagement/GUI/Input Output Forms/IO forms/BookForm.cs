using Project_BookCoffeeManagement.BLL;
using Project_BookCoffeeManagement.BLL.Books;
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
    public partial class BookForm : FormTemplate
    {
        private string mode = "";    // delete, update or add
        private BookManager manager;
        private AuthorManager autManager;
        private PublisherManager pubManager;
        private Book oldBook = null;
        private Dictionary<string, BookDetails> recommendDetails;

        #region Init
        public BookForm(string cmd)
        {    
            InitializeComponent();
            ThreadManager.DisplayLoadingScreen();
            LoadForm(cmd);
            LoadData();
            ThreadManager.CloseLoadingScreen();
        }

        public BookForm(string cmd, Book book)
        {
            InitializeComponent();
            ThreadManager.DisplayLoadingScreen();
            LoadForm(cmd);
            LoadData(book);
            ThreadManager.CloseLoadingScreen();
        }

        private void LoadData()
        {
            manager = new BookManager();
            autManager = new AuthorManager();
            pubManager = new PublisherManager();
            
            recommendDetails = new Dictionary<string, BookDetails>();
            if (IsAddOrUpdateMode())
                AddRecommendData();
            else if (IsDeleteMode() || IsViewMode())
            {
                DisableFields();
                displayBookInfoToForm();
            }
        }

        private void LoadData(Book book)
        {
            oldBook = book;
            LoadData();
            displayBookInfoToForm();
        }

        private void LoadForm(string cmd)
        {
            LoadTheme();
            LoadLanguage();
            switch (cmd)
            {
                case "Add": LoadAddForm(); break;
                case "Update": LoadUpdateForm(); break;
                case "Delete": LoadDeleteForm(); break;
                case "View": LoadViewForm(); break;
            }
        }

        private void LoadViewForm()
        {
            bunifuTileButton_Execute.LabelText = "OK";
            mode = "view";
        }

        private void LoadDeleteForm()
        {
            bunifuTileButton_Execute.LabelText = "Delete book";
            mode = "delete"; 
        }

        private void LoadUpdateForm()
        {
            bunifuTileButton_Execute.LabelText = "Update book";
            mode = "update";
        }

        private void LoadAddForm()
        {
            bunifuTileButton_Execute.LabelText = "Add book";
            mode = "add";
        }
        #endregion

        #region Display
        private void displayBookInfoToForm()
        {
            bunifuCustomTextbox_BookCode.Text = oldBook.BookID;
            bunifuCustomTextbox_Title.Text = oldBook.BookName;

            bunifuDropdown_Status.selectedIndex = Array.IndexOf(bunifuDropdown_Status.Items, oldBook.Status);
            bunifuCustomTextbox_Author.Text = oldBook.AuthorName;
            bunifuCustomTextbox_Publisher.Text = oldBook.PublisherName;
            bunifuCustomTextbox_Price.Text = oldBook.Price.ToString();
            bunifuCustomTextbox_PulishDate.Text = oldBook.PublishDate.Value.Date.ToString("d");
            

            bunifuCustomTextbox_Location.Text = oldBook.Location;        
        }

        private void DisableFields()
        {
            bunifuCustomTextbox_BookCode.ReadOnly = true;
            bunifuDropdown_Status.Items = new string[] { oldBook.Status };
            bunifuDropdown_Status.selectedIndex = 0;
            bunifuCustomTextbox_Title.ReadOnly = true;
            bunifuCustomTextbox_Location.ReadOnly = true;
            bunifuCustomTextbox_Publisher.ReadOnly = true;
            bunifuCustomTextbox_Author.ReadOnly = true;
            bunifuCustomTextbox_PulishDate.ReadOnly = true;
            bunifuCustomTextbox_Price.ReadOnly = true;
        }

        private void AddStatusRecommendation()
        {
            List<string> recommendData = manager.GetBookStatuses();
            bunifuDropdown_Status.Items = recommendData.ToArray();
        }

        private void InitBookDetailsList()
        {
            List<BookDetails> bookDetailsRecommendation = manager.GetBookDetails();
            foreach (BookDetails details in bookDetailsRecommendation)
                recommendDetails.Add(details.Name, details);
        }

        private void AddRecommendData()
        {
            AddStatusRecommendation();
            AddBookDetailsRecommendation();
            AddAuthorRecommendation();
            AddPublisherRecommendation();
        }

        private void AddPublisherRecommendation()
        {
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            collection.AddRange(pubManager.GetPublisherNames().ToArray());
            this.bunifuCustomTextbox_Publisher.AutoCompleteCustomSource = collection;     
        }

        private void AddAuthorRecommendation()
        {
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            collection.AddRange(autManager.GetAuthorNames().ToArray());
            this.bunifuCustomTextbox_Author.AutoCompleteCustomSource = collection;

        }

        private void AddBookDetailsRecommendation()
        {
            InitBookDetailsList();
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            collection.AddRange(recommendDetails.Keys.ToArray());
            this.bunifuCustomTextbox_Title.AutoCompleteCustomSource = collection;
        }
        #endregion

        #region Event handler
        private void bunifuTileButton_Execute_Click(object sender, EventArgs e)
        {
            if (IsViewMode())
            {
                this.Close();
                return;
            }
            ThreadManager.DisplayLoadingScreen();
            Book newBook = new Book();
            try
            {
                newBook.BookID = bunifuCustomTextbox_BookCode.Text;
                newBook.BookName = bunifuCustomTextbox_Title.Text;
                newBook.Location = bunifuCustomTextbox_Location.Text;
                newBook.Status = bunifuDropdown_Status.selectedValue;
                newBook.Price = double.Parse(bunifuCustomTextbox_Price.Text);
                newBook.PublishDate = Convert.ToDateTime(bunifuCustomTextbox_PulishDate.Text).Date;
                newBook.AuthorName = bunifuCustomTextbox_Author.Text;
                newBook.PublisherName = bunifuCustomTextbox_Publisher.Text;     
            }
            catch (Exception ex)
            {
                ErrorManager.MessageDisplay(ex.Message, "", "Error: Can't get data from fields");
                ThreadManager.CloseLoadingScreen();
                return;
            }

            string err = "";
            if (mode != "delete")
                err =  newBook.ValidateField();
            if (err != "")
            {
                ThreadManager.CloseLoadingScreen();
                ErrorManager.MessageDisplay(err, "", "Data input error");
                return;
            }


            err = "";
            if (IsAddOrUpdateMode())
            {
                err = manager.AddOrUpdateBookToDatabase(newBook);
                ThreadManager.CloseLoadingScreen();
                ErrorManager.MessageDisplay(err, "Add/Update a book successfully", "Failed to add/update a book");
            }
            else if (IsDeleteMode())
            {
                err = manager.DeleteBookFromDatabase(bunifuCustomTextbox_BookCode.Text);
                ThreadManager.CloseLoadingScreen();
                ErrorManager.MessageDisplay(err, "Delete a book successfully", "Failed to delete a book");
            }
            if (err == "")
                this.Close();
        }

        #region Load Theme & Language
        private void LoadLanguage()
        {
            LanguageManager LanguageSwitch = new LanguageManager();
            bunifuCustomLabel_HeaderName.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_HeaderName.Tag.ToString());
            bunifuCustomLabel_BookCode.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_BookCode.Name);
            bunifuCustomLabel_Status.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Status.Name);
            bunifuCustomLabel_Title.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Title.Name);
            bunifuCustomLabel_Author.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Author.Name);
            bunifuCustomLabel_Location.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Location.Name);
            bunifuCustomLabel_Pulisher.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Pulisher.Name);
            bunifuCustomLabel_PulishDate.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_PulishDate.Name);
            bunifuCustomLabel_Price.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Price.Name);
            //bunifuTileButton_Execute.LabelText = LanguageSwitch.ChangeName(bunifuTileButton_Execute.Name);
        }

        private void LoadTheme()
        {
            // Label fore color
            bunifuCustomLabel_BookCode.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_Status.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_Title.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_Author.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_Location.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_Pulisher.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_PulishDate.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_Price.ForeColor = ThemeManager.ForeColor;
            // Textbox + combobox
            bunifuCustomTextbox_BookCode.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_BookCode.ForeColor = ThemeManager.ForeColor;
            bunifuDropdown_Status.NomalColor = ThemeManager.BackgroundColor;
            bunifuDropdown_Status.onHoverColor = ThemeManager.BackgroundColor;
            bunifuDropdown_Status.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_Title.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_Title.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_Author.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_Author.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_Location.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_Location.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_Publisher.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_Publisher.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_PulishDate.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_PulishDate.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_Price.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_Price.ForeColor = ThemeManager.ForeColor;
            //Button
            bunifuTileButton_Execute.BackColor = ThemeManager.NormalColor;
            bunifuTileButton_Execute.color = ThemeManager.NormalColor;
            bunifuTileButton_Execute.colorActive = ThemeManager.FocusColor;
            bunifuTileButton_Execute.ForeColor = ThemeManager.ButtonForeColor;
        }
        #endregion

        private bool IsDeleteMode()
        {
            return mode == "delete";
        }

        private bool IsAddOrUpdateMode()
        {
            return mode == "add" || mode == "update";
        }

        private bool IsViewMode()
        {
            return mode == "view";
        }

        private void bunifuCustomTextbox_Title_TextChanged(object sender, EventArgs e)
        {    
            if (recommendDetails.ContainsKey(bunifuCustomTextbox_Title.Text))
            {
                BookDetails details = recommendDetails[bunifuCustomTextbox_Title.Text];
                bunifuCustomTextbox_Author.Text = details.AuthorName;
                bunifuCustomTextbox_Publisher.Text = details.PublisherName;
                bunifuCustomTextbox_PulishDate.Text = details.PublishDate.Value.Date.ToString("d");
                bunifuCustomTextbox_Price.Text = details.Price.ToString();
            }
        }
        #endregion
    }
}
