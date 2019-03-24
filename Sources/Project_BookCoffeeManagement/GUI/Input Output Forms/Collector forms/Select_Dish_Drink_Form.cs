using Project_BookCoffeeManagement.BLL;
﻿using Project_BookCoffeeManagement.BLL.Foods;
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
    public partial class Select_Dish_Drink_Form : FormTemplate_SelectionCollector
    {
        protected FoodManager fdManager;
        protected List<Food> availableFoods;
        public List<Food> selectedFoods;

        public Select_Dish_Drink_Form()
        {
            InitializeComponent();
            LoadHeaderName();
            fdManager = new FoodManager();
            selectedFoods = new List<Food>();
            LoadDataToScreen();
            dataGridView_SelectedItems.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            dataGridView_SelectedItems.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView_SelectedItems.ReadOnly = false;
        }

        protected override void LoadDataToScreen()
        {
            availableFoods = fdManager.GetAvailableMenu();
            dataGridView_AvailableItems.DataSource = availableFoods;
        }

        protected override void bunifuTileButton_AddToSelectedList_Click(object sender, EventArgs e)
        {
            Food temp = GetSelectedItemInAvailableDataGridView<Food>();
            if (temp != null)
            {
                selectedFoods.Add(temp);
                availableFoods.Remove(temp);
                Update();
            }
            
        }

        private void Update()
        {
            dataGridView_SelectedItems.DataSource = null;
            dataGridView_AvailableItems.DataSource = null;
            dataGridView_SelectedItems.DataSource = selectedFoods;
            dataGridView_AvailableItems.DataSource = availableFoods;
        }

        protected override void bunifuTileButton_RemoveToSelectedList_Click(object sender, EventArgs e)
        {
            Food temp = GetSelectedItemInSelectedDataGridView<Food>();
            if (temp != null)
            {
                selectedFoods.Remove(temp);
                availableFoods.Add(temp);
                Update();
            }
        }

        protected override void dataGridView_AvailableItems_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CallMenuForm((Food)GetSelectedItemInAvailableDataGridView<Food>());
        }

        protected override void dataGridView_SelectedItems_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CallMenuForm((Food)GetSelectedItemInSelectedDataGridView<Food>());
        }

        private void CallMenuForm(Food food)
        {
            Form CallForm = new MenuForm("View", food);
            CallForm.ShowDialog();
        }

        protected override void Filter(string keyword)
        {
            List<Food> res = fdManager.Filter(keyword, availableFoods);
            dataGridView_AvailableItems.DataSource = res;
        }
    }
}
