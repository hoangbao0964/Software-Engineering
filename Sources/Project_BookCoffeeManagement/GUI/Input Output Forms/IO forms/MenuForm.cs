using Project_BookCoffeeManagement.BLL;
using Project_BookCoffeeManagement.BLL.Foods;
using Project_BookCoffeeManagement.Entities.Foods;
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
    public partial class MenuForm : FormTemplate
    {
        private string mode;
        private FoodManager manager;
        private Food oldFood = null;
        private Dictionary<string, Food> recommendFood = null;

        private void Load(string cmd)
        {
            ThreadManager.DisplayLoadingScreen();
            manager = new FoodManager();
            switch (cmd)
            {
                case "Add": LoadAddForm(); break;
                case "Update": LoadUpdateForm(); break;
                case "Delete": LoadDeleteForm(); break;
                case "View": LoadViewForm(); break;
            }
            LoadTheme();
            LoadLanguage();
            AddRecommendData();
            ThreadManager.CloseLoadingScreen();
        }

        private void AddRecommendData()
        {
            AddStatusRecommendation();
            AddFoodNameRecommendation();
        }

        private void AddFoodNameRecommendation()
        {
            InitFoodRecommendationData();
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            collection.AddRange(recommendFood.Keys.ToArray());
            this.bunifuCustomTextbox_Name.AutoCompleteCustomSource = collection;
        }

        private void InitFoodRecommendationData()
        {
            List<Food> foodData = manager.GetMenu();
            recommendFood = new Dictionary<string, Food>();
            foreach (Food fd in foodData)
                recommendFood.Add(fd.Name, fd);
        }

        private void AddStatusRecommendation()
        {
            List<string> recommendData = manager.GetFoodStatusList();
            bunifuDropdown_Status.Items = recommendData.ToArray();
        }

        public MenuForm(string cmd)
        {
            InitializeComponent();
            Load(cmd);
            
        }

        public MenuForm(string cmd, Food food)
        {
            InitializeComponent();
            Load(cmd, food);
        }

        private void Load(string cmd, Food food)
        {
            oldFood = food;
            oldFood.UpdateIngredientList();
            Load(cmd);            
            displayFoodToScreen();
        }

        private void displayFoodToScreen()
        {
            bunifuCustomTextbox_Name.Text = oldFood.Name;
            bunifuCustomTextbox_Description.Text = oldFood.Description;
            if (Array.IndexOf(bunifuDropdown_Status.Items, oldFood.Status) == -1)
                bunifuDropdown_Status.AddItem(oldFood.Status);
            bunifuDropdown_Status.selectedIndex = Array.IndexOf(bunifuDropdown_Status.Items, oldFood.Status);
            bunifuMetroTextbox_Price.Text = oldFood.Price.ToString();
            displayIngredientsToScreen(oldFood.GetIngredients());
        }

        private void displayIngredientsToScreen(List<Ingredient> ingredients)
        {
            bunifuCustomTextbox__list_selectedIngredients.Text = "";
            foreach (Ingredient ingredient in ingredients)
            {
                bunifuCustomTextbox__list_selectedIngredients.Text = bunifuCustomTextbox__list_selectedIngredients.Text +
                                                                            ingredient.Name +
                                                                            " x " + ingredient.Quantity;
                bunifuCustomTextbox__list_selectedIngredients.Text += "\r\n";
            }
            bunifuCustomTextbox__list_selectedIngredients.Tag = ingredients;
        }

        private void LoadDeleteForm()
        {
            bunifuTileButton_Execute.LabelText = "Delete menu item";
            mode = "delete";
            DisableFields();
        }

        private void DisableFields()
        {
            bunifuCustomTextbox_Name.ReadOnly = true;
            bunifuCustomTextbox_Description.ReadOnly = true;
            bunifuDropdown_Status.Items = new string[] { oldFood.Status };
            bunifuMetroTextbox_Price.Enabled = false;
            bunifuImageButton_ChooseIngredient.Enabled = false;
        }

        private void LoadUpdateForm()
        {
            bunifuTileButton_Execute.LabelText = "Update menu item";
            mode = "update";
        }

        private void LoadAddForm()
        {
            bunifuTileButton_Execute.LabelText = "Add menu item";
            mode = "add";
        }

        private void LoadViewForm()
        {
            bunifuTileButton_Execute.LabelText = "OK";
            mode = "view";
            DisableFields();
        }

        private void bunifuImageButton_Close_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton_ChooseIngredient_Click(object sender, EventArgs e)
        {
            Select_Ingredient_Form CallForm = new Select_Ingredient_Form();
            if (CallForm.ShowDialog() == DialogResult.OK)
                bunifuCustomTextbox__list_selectedIngredients.Tag = CallForm.selectedIngredients;
            displayIngredientsToScreen(CallForm.selectedIngredients);
        }

        private void bunifuTileButton_Execute_Click(object sender, EventArgs e)
        {
            if (mode == "view")
            {
                this.Close();
                return;
            }
            ThreadManager.DisplayLoadingScreen();
            Food newFood = new Food();
            try
            {
                newFood.Name = bunifuCustomTextbox_Name.Text;
                newFood.Description = bunifuCustomTextbox_Description.Text;
                newFood.Status = bunifuDropdown_Status.selectedValue;
                newFood.Price = Double.Parse(bunifuMetroTextbox_Price.Text);
                newFood.SetIngredients((List<Ingredient>)bunifuCustomTextbox__list_selectedIngredients.Tag);
            }
            catch (Exception ex)
            {
                ThreadManager.CloseLoadingScreen();
                ErrorManager.MessageDisplay(ex.Message, "", "Extract Data Failed");
                return;
            }

            string err = "";
            if (mode != "delete")
                err = newFood.ValidateFields();
            if (err != "")
            {
                ThreadManager.CloseLoadingScreen();
                ErrorManager.MessageDisplay(err, "", "Incorrect format");  
                return;
            }

            if (mode == "add" || mode == "update")
            {
                err = manager.AddOrUpdateMenuItem(newFood);
                ThreadManager.CloseLoadingScreen();
                ErrorManager.MessageDisplay(err, "Add/Update Data Successfully", "Add/Update Data Failed");
            }
            else if (mode == "delete")
            {
                err = manager.DeleteMenuItems(newFood.Name);
                ThreadManager.CloseLoadingScreen();
                ErrorManager.MessageDisplay(err, "Delete Data Successfully", "Delete Data Failed");
            }

            if (err == "")
                this.Close();
        }

        private void bunifuCustomTextbox_Name_TextChanged(object sender, EventArgs e)
        {
            if (recommendFood.ContainsKey(bunifuCustomTextbox_Name.Text))
            {
                Food data = recommendFood[bunifuCustomTextbox_Name.Text];
                data.UpdateIngredientList();
                displayIngredientsToScreen(data.GetIngredients());
                bunifuCustomTextbox_Description.Text = data.Description;
                bunifuMetroTextbox_Price.Text = data.Price.ToString();
            }
        }

        #region Load Theme & Language
        private void LoadLanguage()
        {
            LanguageManager LanguageSwitch = new LanguageManager();
            bunifuCustomLabel_HeaderName.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_HeaderName.Tag.ToString());
            bunifuCustomLabel_Name.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Name.Name);
            bunifuCustomLabel_Status.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Status.Name);
            bunifuCustomLabel_Ingredients.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Ingredients.Name);
            bunifuCustomLabel_Description.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Description.Name);
            bunifuCustomLabel_Price.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Price.Name);
        }

        private void LoadTheme()
        {
            panel_Header.BackColor = ThemeManager.NormalColor;
            //Label forecolor
            bunifuCustomLabel_Name.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_Status.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_Ingredients.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_Description.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_Price.ForeColor = ThemeManager.ForeColor;
            //Textbox & combobox
            bunifuCustomTextbox_Name.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_Name.ForeColor = ThemeManager.ForeColor;
            bunifuDropdown_Status.BackColor = ThemeManager.BackgroundColor;
            bunifuDropdown_Status.ForeColor = ThemeManager.ForeColor;
            bunifuDropdown_Status.NomalColor = ThemeManager.BackgroundColor;
            bunifuDropdown_Status.onHoverColor = ThemeManager.FocusColor;
            bunifuCustomTextbox__list_selectedIngredients.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox__list_selectedIngredients.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_Description.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_Description.ForeColor = ThemeManager.ForeColor;
            bunifuMetroTextbox_Price.BackColor = ThemeManager.BackgroundColor;
            bunifuMetroTextbox_Price.BorderColorFocused = ThemeManager.MenuColor;
            bunifuMetroTextbox_Price.BorderColorIdle = ThemeManager.MenuColor;
            bunifuMetroTextbox_Price.BorderColorMouseHover = ThemeManager.MenuColor;
            bunifuMetroTextbox_Price.ForeColor = ThemeManager.ForeColor;
            //Button
            bunifuTileButton_Execute.BackColor = ThemeManager.NormalColor;
            bunifuTileButton_Execute.color = ThemeManager.NormalColor;
            bunifuTileButton_Execute.colorActive = ThemeManager.FocusColor;
            bunifuTileButton_Execute.ForeColor = ThemeManager.ButtonForeColor;
            bunifuImageButton_ChooseIngredient.BackColor = ThemeManager.BackgroundColor;
        }
        #endregion
    }
}
