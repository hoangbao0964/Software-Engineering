using Project_BookCoffeeManagement.BLL;
using Project_BookCoffeeManagement.BLL.Books;
using Project_BookCoffeeManagement.BLL.Foods;
using Project_BookCoffeeManagement.BLL.Orders;
using Project_BookCoffeeManagement.BLL.People.Customers;
using Project_BookCoffeeManagement.BLL.People.Staffs;
using Project_BookCoffeeManagement.BLL.Stocks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_BookCoffeeManagement.GUI.Input_Output_Forms.IO_forms
{
    public partial class SearchForm : FormTemplate
    {
        private string strFeature;
        private List<string> Categories = new List<string>();
        public List<Object> returnData = null;

        public SearchForm()
        {
            InitializeComponent();
            LoadTheme();
            LoadLanguage();
        }

        public SearchForm(string strFeature)
        {
            this.strFeature = strFeature;
            InitializeComponent();
            AddCategoriesBaseOnFeature(strFeature);
            Categories.Add("All");
            LoadTheme();
            LoadLanguage();
        }

        private void AddCategoriesBaseOnFeature(string strFeature)
        {
            switch(strFeature)
            {
                case "Order": AddCategoriesForOrder(); break;
                case "Menu": AddCategoriesForMenu(); break;
                case "Book": AddCategoriesForBook(); break;
                case "VIP": AddCategoriesForVIP(); break;
                case "Staff": AddCategoriesForStaff(); break;
                case "Stock": AddCategoriesForStock(); break;
                case "History": AddCategoriesForHistory(); break;
                case "Wishlist": AddCategoriesForWishlist(); break;
            }
        }

        #region Handling categories of all features
        private void AddCategoriesForOrder()
        {
            Categories.Add("Order ID");
            Categories.Add("Date created");
            Categories.Add("VIP");
            Categories.Add("Staff name");
            Categories.Add("Book title");
            Categories.Add("Dish/drink name");
            AddToDropBox();
        }

        private void AddCategoriesForBook()
        {
            Categories.Add("Book ID");
            Categories.Add("Title");
            Categories.Add("Author");
            Categories.Add("Pulisher");
            AddToDropBox();
        }

        private void AddCategoriesForMenu()
        {
            Categories.Add("Name");
            Categories.Add("Ingredient");
            AddToDropBox();
        }

        private void AddCategoriesForVIP()
        {
            Categories.Add("VIP ID");
            Categories.Add("Full name");
            Categories.Add("Civilian ID");
            Categories.Add("Phone number");
            AddToDropBox();
        }

        private void AddCategoriesForStaff()
        {
            Categories.Add("Staff ID");
            Categories.Add("Username");
            Categories.Add("Full name");
            Categories.Add("Position");
            Categories.Add("Civilian ID");
            Categories.Add("Phone number");
            AddToDropBox();
        }

        private void AddCategoriesForStock()
        {
            Categories.Add("Name");
            Categories.Add("Type");
            Categories.Add("Producer");
            AddToDropBox();
        }

        private void AddCategoriesForHistory()
        {
            Categories.Add("Order ID");
            Categories.Add("Date created");
            Categories.Add("VIP");
            Categories.Add("Staff name");
            Categories.Add("Book title");
            Categories.Add("Dish/drink name");
            AddToDropBox();
        }

        private void AddCategoriesForWishlist()
        {
            Categories.Add("Title");
            Categories.Add("Author");
            Categories.Add("Pulisher");
            AddToDropBox();
        }

        private void AddToDropBox()
        {
            //Add categories to drop down list
            for (int i = 0; i < Categories.Count(); i++)
            {
                bunifuDropdown_Category_1.AddItem(Categories[i]);
                bunifuDropdown_Category_2.AddItem(Categories[i]);
                bunifuDropdown_Category_3.AddItem(Categories[i]);
            }
        }
        #endregion

        private List<object> executeSearch()
        {
            // Dummy init 
            ErrorManager.MessageDisplay("This function is not implemented", "", "Sorry. We haven't implement this function (yet)" + Environment.NewLine + "Sorry for the inconvinient");
            return null;

            List<object> res = new List<object>();
            string searchPharse1 = bunifuCustomTextbox_Filter_1.Text;
            string searchPharse2 = bunifuCustomTextbox_Filter_2.Text;
            string searchPharse3 = bunifuCustomTextbox_Filter_3.Text;
            string type1 = bunifuDropdown_Category_1.selectedValue;
            string type2 = bunifuDropdown_Category_2.selectedValue;
            string type3 = bunifuDropdown_Category_3.selectedValue;
            string searchConstraint1 = bunifuDropdown_Connector_1.selectedValue;
            string searchConstraint2 = bunifuDropdown_Connector_2.selectedValue;

            switch (strFeature)
            {
                case "Order":
                    OrderManager orderManager = new OrderManager();
                    res = orderManager.SearchOrder(searchPharse1, type1, searchPharse2, type2, searchPharse3, type3, searchConstraint1, searchConstraint2);
                    break;
                case "Menu":
                    FoodManager menuManager = new FoodManager();
                    res = menuManager.SearchFood(searchPharse1, type1, searchPharse2, type2, searchPharse3, type3, searchConstraint1, searchConstraint2);
                    break;
                case "Book":
                    BookManager bookManager = new BookManager();
                    res = bookManager.SearchBook(searchPharse1, type1, searchPharse2, type2, searchPharse3, type3, searchConstraint1, searchConstraint2);
                    break;
                case "VIP":
                    VIPManager vipManager = new VIPManager();
                    res = vipManager.SearchVip(searchPharse1, type1, searchPharse2, type2, searchPharse3, type3, searchConstraint1, searchConstraint2); ;
                    break;
                case "Staff":
                    StaffManager staffManager = new StaffManager();
                    res = staffManager.SearchStaff(searchPharse1, type1, searchPharse2, type2, searchPharse3, type3, searchConstraint1, searchConstraint2);
                    break;
                case "Stock":
                    StockManager stockManager = new StockManager();
                    res = stockManager.SearchOrder(searchPharse1, type1, searchPharse2, type2, searchPharse3, type3, searchConstraint1, searchConstraint2);
                    break;
                case "History":
                    OrderManager transactionManager = new OrderManager();
                    res = transactionManager.SearchTransaction(searchPharse1, type1, searchPharse2, type2, searchPharse3, type3, searchConstraint1, searchConstraint2);
                    break;
                case "Wishlist":
                    BookManager wishlistManager = new BookManager();
                    res = wishlistManager.SearchWishList(searchPharse1, type1, searchPharse2, type2, searchPharse3, type3, searchConstraint1, searchConstraint2);
                    break;
            }

            return res;
        }

        #region Load Theme & Language
        private void LoadLanguage()
        {
            LanguageManager LanguageSwitch = new LanguageManager();
            bunifuCustomLabel_HeaderName.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_HeaderName.Tag.ToString());
            bunifuCustomLabel_Filter_1.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Filter_1.Name);
            bunifuCustomLabel_Filter_2.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Filter_2.Name);
            bunifuCustomLabel_Filter_3.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Filter_3.Name);
            bunifuCustomLabel_1.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_1.Name);
            bunifuCustomLabel1.Text = LanguageSwitch.ChangeName(bunifuCustomLabel1.Name);
            bunifuCustomLabel2.Text = LanguageSwitch.ChangeName(bunifuCustomLabel2.Name);
        }

        private void LoadTheme()
        {
            panel_Header.BackColor = ThemeManager.NormalColor;
            //Label fore color
            bunifuCustomLabel_Filter_1.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_Filter_2.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_Filter_3.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_1.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel1.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel2.ForeColor = ThemeManager.ForeColor;
            //Textbox color
            bunifuCustomTextbox_Filter_1.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_Filter_1.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_Filter_2.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_Filter_2.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_Filter_3.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_Filter_3.ForeColor = ThemeManager.ForeColor;
            //Combobox color
            bunifuDropdown_Connector_1.BackColor = ThemeManager.BackgroundColor;
            bunifuDropdown_Connector_1.NomalColor = ThemeManager.BackgroundColor;
            bunifuDropdown_Connector_1.onHoverColor = ThemeManager.FocusColor;
            bunifuDropdown_Connector_1.ForeColor = ThemeManager.ForeColor;
            bunifuDropdown_Connector_2.BackColor = ThemeManager.BackgroundColor;
            bunifuDropdown_Connector_2.NomalColor = ThemeManager.BackgroundColor;
            bunifuDropdown_Connector_2.onHoverColor = ThemeManager.FocusColor;
            bunifuDropdown_Connector_2.ForeColor = ThemeManager.ForeColor;
            bunifuDropdown_Category_1.BackColor = ThemeManager.BackgroundColor;
            bunifuDropdown_Category_1.NomalColor = ThemeManager.BackgroundColor;
            bunifuDropdown_Category_1.onHoverColor = ThemeManager.FocusColor;
            bunifuDropdown_Category_1.ForeColor = ThemeManager.ForeColor;
            bunifuDropdown_Category_2.BackColor = ThemeManager.BackgroundColor;
            bunifuDropdown_Category_2.NomalColor = ThemeManager.BackgroundColor;
            bunifuDropdown_Category_2.onHoverColor = ThemeManager.FocusColor;
            bunifuDropdown_Category_2.ForeColor = ThemeManager.ForeColor;
            bunifuDropdown_Category_3.BackColor = ThemeManager.BackgroundColor;
            bunifuDropdown_Category_3.NomalColor = ThemeManager.BackgroundColor;
            bunifuDropdown_Category_3.onHoverColor = ThemeManager.FocusColor;
            bunifuDropdown_Category_3.ForeColor = ThemeManager.ForeColor;
            //Button
            bunifuTileButton_Search.BackColor = ThemeManager.NormalColor;
            bunifuTileButton_Search.color = ThemeManager.NormalColor;
            bunifuTileButton_Search.colorActive = ThemeManager.FocusColor;
            bunifuTileButton_Search.ForeColor = ThemeManager.ButtonForeColor;
        }
        #endregion

        private void bunifuTileButton_Search_Click(object sender, EventArgs e)
        {
            returnData =  executeSearch();
        }
    }
}
