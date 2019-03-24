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
    public partial class WishlistForm : FormTemplate
    {
        private string mode = "";    // delete, update or add
        private BookManager manager;
        private AuthorManager autManager;
        private PublisherManager pubManager;
        private BookDetails oldDetails = null;

        public WishlistForm(string cmd)
        {
            InitializeComponent();
            ThreadManager.DisplayLoadingScreen();
            LoadForm(cmd);
            LoadData();
            ThreadManager.CloseLoadingScreen();
            
        }

        private void LoadForm(string cmd)
        {
            switch (cmd)
            {
                case "Add": LoadAddForm(); break;
                case "Update": LoadUpdateForm(); break;
                case "Delete": LoadDeleteForm(); break;
                case "View": LoadViewForm(); break;
            }
            LoadTheme();
            LoadLanguage();
        }

        public WishlistForm(string cmd, BookDetails bkDetails)
        {
            InitializeComponent();
            LoadForm(cmd);
            LoadData(bkDetails);
        }

        private void LoadData()
        {
            manager = new BookManager();
            autManager = new AuthorManager();
            pubManager = new PublisherManager();          
            if (mode == "add" || mode == "update")
                AddRecommendData();
            else if (mode == "delete" || mode == "view")
            {
                DisableFields();
                displayBookInfoToForm();
            }
        }     

        private void LoadData(BookDetails bkDetail)
        {
            oldDetails = bkDetail;
            LoadData();
            displayBookInfoToForm();
        }

        private void LoadUpdateForm()
        {
            bunifuTileButton_Execute.LabelText = "Update wishlist item";
            mode = "update";
        }

        private void LoadAddForm()
        {
            bunifuTileButton_Execute.LabelText = "Add wishlist item";
            mode = "add";
        }

        private void LoadDeleteForm()
        {
            bunifuTileButton_Execute.LabelText = "Delete wishlist item";
            mode = "delete";
        }

        private void LoadViewForm()
        {
            bunifuTileButton_Execute.LabelText = "OK";
            mode = "view";
        }

        private void AddRecommendData()
        {
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            collection.AddRange(autManager.GetAuthorNames().ToArray());
            this.bunifuCustomTextbox_Author.AutoCompleteCustomSource = collection;

            AutoCompleteStringCollection collection1 = new AutoCompleteStringCollection();
            collection1.AddRange(pubManager.GetPublisherNames().ToArray());
            this.bunifuCustomTextbox_Pulisher.AutoCompleteCustomSource = collection1;
        }

        private void displayBookInfoToForm()
        {
            if (oldDetails != null)
            {
                bunifuCustomTextbox_Title.Text = oldDetails.Name;
                bunifuCustomTextbox_Author.Text = oldDetails.AuthorName;
                bunifuCustomTextbox_Pulisher.Text = oldDetails.PublisherName;
                bunifuCustomTextbox_PulishDate.Text = oldDetails.PublishDate.Value.Date.ToString("d");
                bunifuCustomTextbox_Price.Text = oldDetails.Price.ToString();
            }
        }

        private void DisableFields()
        {
            bunifuCustomTextbox_Title.ReadOnly = true;
            bunifuCustomTextbox_Author.ReadOnly = true;
            bunifuCustomTextbox_Pulisher.ReadOnly = true;
            bunifuCustomTextbox_PulishDate.ReadOnly = true;
            bunifuCustomTextbox_Price.ReadOnly = true;
        }

        private void bunifuTileButton_Execute_Click(object sender, EventArgs e)
        {
            if (mode == "view")
            {
                this.Close();
                return;
            }

            ThreadManager.DisplayLoadingScreen();
            BookDetails newWishlist = new BookDetails();
            try
            {
                newWishlist.Name = bunifuCustomTextbox_Title.Text;
                newWishlist.Price = double.Parse(bunifuCustomTextbox_Price.Text);
                newWishlist.PublishDate = Convert.ToDateTime(bunifuCustomTextbox_PulishDate.Text).Date;
                newWishlist.AuthorName = bunifuCustomTextbox_Author.Text;
                newWishlist.PublisherName = bunifuCustomTextbox_Pulisher.Text;
            }
            catch (Exception ex)
            {
                ThreadManager.CloseLoadingScreen();
                ErrorManager.MessageDisplay(ex.Message, "", "Error: Can't get data from fields");
                return;
            }

            string err = "";
            if (mode != "delete")
                err = newWishlist.ValidateFields();
            if (err != "")
            {
                ThreadManager.CloseLoadingScreen();
                ErrorManager.MessageDisplay(err, "", "Incorrect format");
                return;
            }

            if (mode == "add" || mode == "update")
            {
                err = manager.AddOrUpdateBookToWishlist(newWishlist);
                ThreadManager.CloseLoadingScreen();
                ErrorManager.MessageDisplay(err, "Add/Update a book to wishlist successfully", "Failed to add/update a book to wishlist");
            }
            else if (mode == "delete")
            {
                err = manager.DeleteBookFromWishlist (bunifuCustomTextbox_Title.Text);
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
            bunifuCustomLabel_Title.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Title.Name);
            bunifuCustomLabel_Author.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Author.Name);
            bunifuCustomLabel_Pulisher.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Pulisher.Name);
            bunifuCustomLabel_PulishDate.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_PulishDate.Name);
            bunifuCustomLabel_Price.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Price.Name);
        }

        private void LoadTheme()
        {
            //Header
            panel_Header.BackColor = ThemeManager.NormalColor;
            //Background
            this.BackColor = ThemeManager.BackgroundColor;
            //Label
            bunifuCustomLabel_Title.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_Author.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_Pulisher.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_PulishDate.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_Price.ForeColor = ThemeManager.ForeColor;
            //Textbox + combobox
            bunifuCustomTextbox_Title.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_Title.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_Author.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_Author.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_Pulisher.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_Pulisher.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_PulishDate.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_PulishDate.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_Price.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_Price.ForeColor = ThemeManager.ForeColor;
            //Button color
            bunifuTileButton_Execute.BackColor = ThemeManager.NormalColor;
            bunifuTileButton_Execute.color = ThemeManager.NormalColor;
            bunifuTileButton_Execute.colorActive = ThemeManager.FocusColor;
            bunifuTileButton_Execute.ForeColor = ThemeManager.ButtonForeColor;
        }
        #endregion
    }
}
