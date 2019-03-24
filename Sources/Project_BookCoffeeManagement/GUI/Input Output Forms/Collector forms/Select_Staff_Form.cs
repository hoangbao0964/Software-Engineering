using Project_BookCoffeeManagement.BLL;
﻿using Project_BookCoffeeManagement.BLL.People.Staffs;
using Project_BookCoffeeManagement.Entities.People.Staffs;
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

namespace Project_BookCoffeeManagement.GUI.Input_Output_Forms.Collector_forms
{
    public partial class Select_Staff_Form : FormTemplate_SelectionCollector
    {
        protected List<Staff> staffs;
        public List<Staff> selectedStaff;
        protected StaffManager manager;

        public Select_Staff_Form()
        {
            InitializeComponent();
            LoadHeaderName();
            manager = new StaffManager();
            selectedStaff = new List<Staff>();

            LoadDataToScreen();
            dataGridView_SelectedItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        protected override void LoadDataToScreen()
        {
            staffs = manager.GetStaffs();
            dataGridView_AvailableItems.DataSource = staffs;
        }

        protected override void bunifuTileButton_AddToSelectedList_Click(object sender, EventArgs e)
        {
            Staff temp = GetSelectedItemInAvailableDataGridView<Staff>();
            staffs.Remove(temp);
            selectedStaff.Add(temp);
            UpdateDataGrid();
        }

        protected override void bunifuTileButton_RemoveToSelectedList_Click(object sender, EventArgs e)
        {
            Staff temp = GetSelectedItemInSelectedDataGridView<Staff>();
            selectedStaff.Remove(temp);
            staffs.Add(temp);
            UpdateDataGrid();
        }

        private void UpdateDataGrid()
        {
            dataGridView_AvailableItems.DataSource = null;
            dataGridView_AvailableItems.DataSource = staffs;
            dataGridView_SelectedItems.DataSource = null;
            dataGridView_SelectedItems.DataSource = selectedStaff;
        }

        protected override void dataGridView_AvailableItems_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Form CallForm = new StaffForm("View", GetSelectedItemInAvailableDataGridView<Staff>());
            CallForm.ShowDialog();
        }

        protected override void dataGridView_SelectedItems_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Form CallForm = new StaffForm("View", GetSelectedItemInSelectedDataGridView<Staff>());
            CallForm.ShowDialog();
        }

        protected override void Filter(string keyword)
        {
            List<Staff> res = manager.Filter(keyword, staffs);
            dataGridView_AvailableItems.DataSource = res;
        }
    }
}
