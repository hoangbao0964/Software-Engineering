using Project_BookCoffeeManagement.BLL;
using Project_BookCoffeeManagement.BLL.Stocks;
using Project_BookCoffeeManagement.Entities.Stocks;
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
    public partial class Stock_ItemForm : FormTemplate
    {
        private string mode;
        private StockManager manager;
        StockItem oldItem = null; 

        public Stock_ItemForm(string cmd)
        {
            InitializeComponent();
            ThreadManager.DisplayLoadingScreen();
            Load(cmd);
            ThreadManager.CloseLoadingScreen();
        }

        public Stock_ItemForm(string cmd, StockItem stockItem)
        {
            InitializeComponent();
            ThreadManager.DisplayLoadingScreen();
            Load(cmd, stockItem);
            ThreadManager.CloseLoadingScreen();

        }

        private void Load(string cmd, StockItem stockItem)
        {
            Load(cmd);
            oldItem = stockItem;
            DisplayItemOnScreen();
        }

        private void DisplayItemOnScreen()
        {
            bunifuCustomTextbox_Name.Text = oldItem.Name;
            bunifuCustomTextbox_Producer.Text = oldItem.ProducerName;
            bunifuCustomTextbox_Quantity.Text = oldItem.Quantity.ToString();
            bunifuCustomTextbox_Note.Text = oldItem.Description;
        }

        private void Load(string cmd)
        {
            manager = new StockManager();
            LoadTheme();
            LoadLanguage();
            switch (cmd)
            {
                case "Add": LoadAddForm(); break;
                case "Update": LoadUpdateForm(); break;
                case "View": LoadViewForm(); break;
            }
            AddRecommendData();
        }
    
        private void LoadUpdateForm()
        {
            bunifuTileButton_Execute.LabelText = "Update item";
            mode = "update";
            bunifuCustomTextbox_Name.ReadOnly = true;
        }

        private void LoadAddForm()
        {
            bunifuTileButton_Execute.LabelText = "Add item";
            mode = "add";
        }

        #region Load Theme & Language
        private void LoadLanguage()
        {
            LanguageManager LanguageSwitch = new LanguageManager();
            bunifuCustomLabel_HeaderName.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_HeaderName.Tag.ToString());
            bunifuCustomLabel_Name.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Name.Name);
            bunifuCustomLabel_Type.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Type.Name);
            bunifuCustomLabel_Producer.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Producer.Name);
            //bunifuCustomLabel_ExpDate.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_ExpDate.Name);
            bunifuCustomLabel_Note.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Note.Name);
        }

        private void LoadTheme()
        {
            //Label
            panel_Header.BackColor = ThemeManager.NormalColor;
            bunifuCustomLabel_Name.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_Type.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_Producer.ForeColor = ThemeManager.ForeColor;
            //bunifuCustomLabel_ExpDate.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_Note.ForeColor = ThemeManager.ForeColor;
            //Textbox + combobox
            bunifuCustomTextbox_Name.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_Name.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_Producer.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_Producer.ForeColor = ThemeManager.ForeColor;
            //bunifuCustomTextbox_ExpDate.BackColor = ThemeManager.BackgroundColor;
            //bunifuCustomTextbox_ExpDate.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_Note.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_Note.ForeColor = ThemeManager.ForeColor;
            bunifuDropdown_Type.NomalColor = ThemeManager.BackgroundColor;
            bunifuDropdown_Type.onHoverColor = ThemeManager.FocusColor;
            bunifuDropdown_Type.ForeColor = ThemeManager.ForeColor;
            //Button
            bunifuTileButton_Execute.BackColor = ThemeManager.NormalColor;
            bunifuTileButton_Execute.color = ThemeManager.NormalColor;
            bunifuTileButton_Execute.colorActive = ThemeManager.FocusColor;
            bunifuTileButton_Execute.ForeColor = ThemeManager.ButtonForeColor;
        }
        #endregion

        private void LoadViewForm()
        {
            bunifuTileButton_Execute.LabelText = "OK";
            mode = "view";
            DisableFields();
        }

        private void DisableFields()
        {
            bunifuCustomTextbox_Name.ReadOnly = true;
            bunifuCustomTextbox_Producer.ReadOnly = true;
            bunifuCustomTextbox_Note.ReadOnly = true;
            bunifuCustomTextbox_Quantity.ReadOnly = true;
        }

        private void AddRecommendData()
        {
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            collection.AddRange(manager.GetProducerList().ToArray());
            this.bunifuCustomTextbox_Producer.AutoCompleteCustomSource = collection;
        }

        private void bunifuTileButton_Execute_Click(object sender, EventArgs e)
        {
            if (mode == "view")
            {
                this.Close();
                return;
            }

            ThreadManager.DisplayLoadingScreen();
            StockItem newItem = new StockItem();
            try
            {
                newItem.Name = bunifuCustomTextbox_Name.Text;
                newItem.Description = bunifuCustomTextbox_Note.Text;
                newItem.ProducerName = bunifuCustomTextbox_Producer.Text;
                if (mode == "add")
                    newItem.Quantity = 0;
            }
            catch (Exception ex)
            {
                ThreadManager.CloseLoadingScreen();
                ErrorManager.MessageDisplay(ex.Message, "", "Error: Can't get data from fields");
                return;
            }

            string err = newItem.ValidateFields();
            if (err != "")
            {
                ThreadManager.CloseLoadingScreen();
                ErrorManager.MessageDisplay(err, "", "Data format error");
                return;
            }


            err = manager.AddorUpdateStockIngredient(newItem);
            ThreadManager.CloseLoadingScreen();
            ErrorManager.MessageDisplay(err, "Add/Update new item success", "Add/Update new item failed");
            if (err == "")
                this.Close();
            
        }

    }
}
