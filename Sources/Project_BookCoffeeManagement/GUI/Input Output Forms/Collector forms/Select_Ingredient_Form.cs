using Project_BookCoffeeManagement.BLL;
﻿using Project_BookCoffeeManagement.BLL.Foods;
using Project_BookCoffeeManagement.Entities.Foods;
using Project_BookCoffeeManagement.Entities.Stocks;
using Project_BookCoffeeManagement.GUI.Input_Output_Forms.IO_forms;
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
    public partial class Select_Ingredient_Form : FormTemplate_SelectionCollector
    {
        protected IngredientManager igrManager;
        protected List<IngredientDetails> ingredientDetails;
        public List<Ingredient> selectedIngredients;

        public Select_Ingredient_Form()
        {
            InitializeComponent();
            LoadHeaderName();
            igrManager = new IngredientManager();
            selectedIngredients = new List<Ingredient>();
            dataGridView_SelectedItems.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            dataGridView_SelectedItems.SelectionMode = DataGridViewSelectionMode.CellSelect;
            
            LoadDataToScreen();
        }

        protected override void LoadDataToScreen()
        {
            ingredientDetails = igrManager.GetIngredientDetails();
            dataGridView_AvailableItems.DataSource = ingredientDetails;
        }

        protected override void bunifuTileButton_AddToSelectedList_Click(object sender, EventArgs e)
        {
            IngredientDetails temp = GetSelectedItemInAvailableDataGridView<IngredientDetails>();
            ingredientDetails.Remove(temp);
            Ingredient newData = new Ingredient(1, temp);
            selectedIngredients.Add(newData);
            Update();
        }

        protected override void bunifuTileButton_RemoveToSelectedList_Click(object sender, EventArgs e)
        {
            Ingredient temp = GetSelectedItemInSelectedDataGridView<Ingredient>();
            selectedIngredients.Remove(temp);
            ingredientDetails.Add(temp.GetIngredientDetails());
            Update();
        }

        private void Update()
        {
            dataGridView_AvailableItems.DataSource = null;
            dataGridView_AvailableItems.DataSource = ingredientDetails;
            dataGridView_SelectedItems.DataSource = null;
            dataGridView_SelectedItems.DataSource = selectedIngredients;
            dataGridView_SelectedItems.ReadOnly = false;
            /*
            if (dataGridView_SelectedItems.Rows.Count > 0)
            {
                dataGridView_SelectedItems.Columns[1].ReadOnly = false;
                dataGridView_SelectedItems.Columns[2].ReadOnly = false;
            }
            */
        }

        protected override void dataGridView_AvailableItems_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        { }

        protected override void dataGridView_SelectedItems_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        { }

        protected override void Filter(string keyword)
        {
            List<IngredientDetails> res = igrManager.Filter(keyword, ingredientDetails);
            dataGridView_AvailableItems.DataSource = res;
        }
    }
}
