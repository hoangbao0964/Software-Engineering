using Project_BookCoffeeManagement.BLL;
using Project_BookCoffeeManagement.BLL.Stocks;
using Project_BookCoffeeManagement.GUI.Input_Output_Forms.Collector_forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project_BookCoffeeManagement.Entities.Foods;
using Project_BookCoffeeManagement.Entities.Stocks;

namespace Project_BookCoffeeManagement.GUI.Input_Output_Forms.IO_forms
{
    public partial class StockForm : FormTemplate
    {
        private StockManager manager;

        public StockForm()
        {
            InitializeComponent();
            ThreadManager.DisplayLoadingScreen();
            manager = new StockManager();
            LoadTheme();
            LoadLanguage();
            DisplayInfoOnScreen();
            ThreadManager.CloseLoadingScreen();
        }

        private void DisplayInfoOnScreen()
        {
            bunifuCustomTextbox_NameOfKeeper.Text = ParameterManager.GetCurrentStaff().FullName;
            bunifuCustomTextbox_DateCreated.Text = DateTime.Now.ToString();
        }

        private void bunifuImageButton_ChooseIngredient_Click(object sender, EventArgs e)
        {
            Select_StockItems_Form CallForm = new Select_StockItems_Form();
            CallForm.ShowDialog();
            if (CallForm.ShowDialog() == DialogResult.OK)
                bunifuCustomTextbox__list_selectedItems.Tag = CallForm.selectedIngredients;
            DisplayIngredientsToScreen(CallForm.selectedIngredients);
        }

        private void DisplayIngredientsToScreen(List<Ingredient> ingredients)
        {
            bunifuCustomTextbox__list_selectedItems.Text = "";
            foreach (Ingredient ingredient in ingredients)
            {
                bunifuCustomTextbox__list_selectedItems.Text = bunifuCustomTextbox__list_selectedItems.Text +
                                                                            ingredient.Name +
                                                                            " x " + ingredient.Quantity;
                bunifuCustomTextbox__list_selectedItems.Text += "\r\n";
            }
        }

        private void bunifuTileButton_CreateStockOrder_Click(object sender, EventArgs e)
        {
            ThreadManager.DisplayLoadingScreen();
            StockOrder newStockOrder = new StockOrder();
            try
            {
                newStockOrder.DateCreated = Convert.ToDateTime(bunifuCustomTextbox_DateCreated.Text);
                newStockOrder.TotalPayment = double.Parse(bunifuMetroTextbox_GrandTotal.Text);
                newStockOrder.SetStockOrderDetails((List<Ingredient>)bunifuCustomTextbox__list_selectedItems.Tag);
            }
            catch (Exception ex)
            {
                ThreadManager.CloseLoadingScreen();
                ErrorManager.MessageDisplay(ex.Message, "", "Extract data failed");
                return;
            }

            string err = newStockOrder.ValidateFields();
            if (err != "")
            {
                ThreadManager.CloseLoadingScreen();
                ErrorManager.MessageDisplay(err, "", "Data format error");
                return;
            }

            err = manager.AddStockOrder(newStockOrder);
            ThreadManager.CloseLoadingScreen();
            ErrorManager.MessageDisplay(err, "Create stock order successfully", "Create stock order failed");
            if (err == "")
                this.Close();
        }

        #region Load Theme & Language
        private void LoadLanguage()
        {
            LanguageManager LanguageSwitch = new LanguageManager();
            bunifuCustomLabel_HeaderName.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_HeaderName.Tag.ToString());
            bunifuCustomLabel_BillCode.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_BillCode.Name);
            bunifuCustomLabel_CreatedBy.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_CreatedBy.Name);
            bunifuCustomLabel_DateCreated.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_DateCreated.Name);
            bunifuCustomLabel_ListItems.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_ListItems.Name);
            bunifuCustomLabel_TotalPayment.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_TotalPayment.Name);
        }

        private void LoadTheme()
        {
            //Header
            panel_Header.BackColor = ThemeManager.NormalColor;
            //Background
            this.BackColor = ThemeManager.BackgroundColor;
            //Label
            bunifuCustomLabel_BillCode.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_CreatedBy.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_DateCreated.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_ListItems.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_TotalPayment.ForeColor = ThemeManager.ForeColor;
            //textbox
            bunifuCustomTextbox_BillCode.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_BillCode.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_NameOfKeeper.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_NameOfKeeper.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_DateCreated.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_DateCreated.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox__list_selectedItems.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox__list_selectedItems.ForeColor = ThemeManager.ForeColor;
            bunifuMetroTextbox_GrandTotal.BackColor = ThemeManager.BackgroundColor;
            bunifuMetroTextbox_GrandTotal.BorderColorFocused = ThemeManager.ForeColor;
            bunifuMetroTextbox_GrandTotal.BorderColorIdle = ThemeManager.NormalColor;
            bunifuMetroTextbox_GrandTotal.BorderColorMouseHover = ThemeManager.MenuColor;
            bunifuMetroTextbox_GrandTotal.ForeColor = ThemeManager.ForeColor;
            //button
            bunifuImageButton_ChooseIngredient.BackColor = ThemeManager.BackgroundColor;
            bunifuTileButton_CreateStockOrder.BackColor = ThemeManager.NormalColor;
            bunifuTileButton_CreateStockOrder.color = ThemeManager.NormalColor;
            bunifuTileButton_CreateStockOrder.colorActive = ThemeManager.FocusColor;
            bunifuTileButton_CreateStockOrder.ForeColor = ThemeManager.ButtonForeColor;
        }
        #endregion
    }
}
