using Project_BookCoffeeManagement.BLL;
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
    public partial class FormTemplate_SelectionCollector : FormTemplate
    {
        private LanguageManager languageSwitch = new LanguageManager();
        public FormTemplate_SelectionCollector()
        {
            InitializeComponent();
            LoadTheme();            
            LoadLanguage();
        }

        internal LanguageManager LanguageSwitch
        {
            get
            {
                return languageSwitch;
            }

            set
            {
                languageSwitch = value;
            }
        }

        public void LoadHeaderName()
        {
            bunifuCustomLabel_HeaderName.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_HeaderName.Tag.ToString());
        }

        public void LoadLanguage()
        {
            bunifuMetroTextbox_SearchAvailableItems.Text = LanguageSwitch.ChangeName(bunifuMetroTextbox_SearchAvailableItems.Name);
            bunifuMetroTextbox_SearchSelectedItems.Text = LanguageSwitch.ChangeName(bunifuMetroTextbox_SearchSelectedItems.Name);
            groupBox_ListAvailableItems.Text = LanguageSwitch.ChangeName(groupBox_ListAvailableItems.Name);
            groupBox_SelectedItems.Text = LanguageSwitch.ChangeName(groupBox_SelectedItems.Name);
            bunifuTileButton_AddToSelectedList.LabelText = LanguageSwitch.ChangeName(bunifuTileButton_AddToSelectedList.Name);
            bunifuTileButton_RemoveToSelectedList.LabelText = LanguageSwitch.ChangeName(bunifuTileButton_RemoveToSelectedList.Name);
            bunifuCustomLabel_CurrentPayment.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_CurrentPayment.Name);
            bunifuTileButton_Confirm.LabelText = LanguageSwitch.ChangeName(bunifuTileButton_Confirm.Name);
        }

        public void LoadTheme()
        {
            this.BackColor = ThemeManager.BackgroundColor;
            panel_Header.BackColor = ThemeManager.NormalColor;
            groupBox_ListAvailableItems.BackColor = ThemeManager.NormalColor;
            groupBox_SelectedItems.BackColor = ThemeManager.NormalColor;
            groupBox_ListAvailableItems.ForeColor = ThemeManager.ForeColor;
            groupBox_SelectedItems.ForeColor = ThemeManager.ForeColor;
            //Textbox: Search available items
            bunifuMetroTextbox_SearchAvailableItems.BackColor = ThemeManager.BackgroundColor;
            bunifuMetroTextbox_SearchAvailableItems.BorderColorFocused = ThemeManager.NormalColor;
            bunifuMetroTextbox_SearchAvailableItems.BorderColorIdle = ThemeManager.NormalColor;
            bunifuMetroTextbox_SearchAvailableItems.BorderColorMouseHover = ThemeManager.NormalColor;
            //Textbox: Search selected items
            bunifuMetroTextbox_SearchSelectedItems.BackColor = ThemeManager.BackgroundColor;
            bunifuMetroTextbox_SearchSelectedItems.BorderColorFocused = ThemeManager.NormalColor;
            bunifuMetroTextbox_SearchSelectedItems.BorderColorIdle = ThemeManager.NormalColor;
            bunifuMetroTextbox_SearchSelectedItems.BorderColorMouseHover = ThemeManager.NormalColor;
            //Button: Add
            bunifuTileButton_AddToSelectedList.BackColor = ThemeManager.NormalColor;
            bunifuTileButton_AddToSelectedList.color = ThemeManager.NormalColor;
            bunifuTileButton_AddToSelectedList.colorActive = ThemeManager.FocusColor;
            bunifuTileButton_AddToSelectedList.ForeColor = ThemeManager.ButtonForeColor;
            //Button: Remove
            bunifuTileButton_RemoveToSelectedList.BackColor = ThemeManager.NormalColor;
            bunifuTileButton_RemoveToSelectedList.color = ThemeManager.NormalColor;
            bunifuTileButton_RemoveToSelectedList.colorActive = ThemeManager.FocusColor;
            bunifuTileButton_RemoveToSelectedList.ForeColor = ThemeManager.ButtonForeColor;
            //Label: Current payment
            bunifuCustomLabel_CurrentPayment.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomLabel_CurrentPayment.ForeColor = ThemeManager.ForeColor;
            //Textbox: Grand total
            bunifuMetroTextbox_GrandTotal.BackColor = ThemeManager.BackgroundColor;
            bunifuMetroTextbox_GrandTotal.BorderColorFocused = ThemeManager.NormalColor;
            bunifuMetroTextbox_GrandTotal.BorderColorIdle = ThemeManager.NormalColor;
            bunifuMetroTextbox_GrandTotal.BorderColorMouseHover = ThemeManager.NormalColor;
            bunifuMetroTextbox_GrandTotal.ForeColor = ThemeManager.ForeColor;
            //Button: Confirm
            bunifuTileButton_Confirm.BackColor = ThemeManager.NormalColor;
            bunifuTileButton_Confirm.color = ThemeManager.NormalColor;
            bunifuTileButton_Confirm.colorActive = ThemeManager.FocusColor;
            bunifuTileButton_Confirm.ForeColor = ThemeManager.ButtonForeColor;        
        }

        protected virtual void LoadDataToScreen()
        { }

        protected virtual void bunifuTileButton_AddToSelectedList_Click(object sender, EventArgs e)
        { }

        protected virtual void bunifuTileButton_RemoveToSelectedList_Click(object sender, EventArgs e)
        { }

        protected virtual void bunifuTileButton_Confirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        protected virtual void bunifuImageButton_SearchAvailableItems_Click(object sender, EventArgs e)
        {
            Filter(bunifuMetroTextbox_SearchAvailableItems.Text);
        }

        protected virtual void bunifuImageButton_SearchSelectedItems_Click(object sender, EventArgs e)
        {
            ErrorManager.MessageDisplay("This function is blocked", "", "Since it seems useless to search the chosen data since it may cancel choosed items, so we don't implement this function" + Environment.NewLine + "Sorry for the inconvinient");
        }

        protected virtual void bunifuImageButton_Close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        protected virtual T GetSelectedItemInAvailableDataGridView<T>()
        {
            try
            {
                return ((List<T>)dataGridView_AvailableItems.DataSource)[dataGridView_AvailableItems.CurrentCell.RowIndex];
            }
            catch
            {
                return default(T);
            }
        }

        protected virtual T GetSelectedItemInSelectedDataGridView<T>()
        {
            try
            {
                return ((List<T>)dataGridView_SelectedItems.DataSource)[dataGridView_SelectedItems.CurrentCell.RowIndex];
            }
            catch
            {
                return default(T);
            }
        }

        protected virtual void dataGridView_AvailableItems_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        protected virtual void dataGridView_SelectedItems_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void bunifuMetroTextbox_SearchAvailableItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Filter(bunifuMetroTextbox_SearchAvailableItems.Text);
        }

        protected virtual void Filter(string keyword)
        {
            
        }

        private void bunifuMetroTextbox_SearchSelectedItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ErrorManager.MessageDisplay("This function is blocked", "", "Since it seems useless to search the chosen data since it may cancel choosed items, so we don't implement this function" + Environment.NewLine + "Sorry for the inconvinient");
            }
        }
    }
}
