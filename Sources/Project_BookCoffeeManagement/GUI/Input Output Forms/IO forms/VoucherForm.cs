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

namespace Project_BookCoffeeManagement.GUI.Input_Output_Forms.IO_forms
{
    public partial class VoucherForm : FormTemplate
    {
        public VoucherForm()
        {
            InitializeComponent();
            LoadTheme();
            LoadLanguage();
        }

        #region Load Theme & Language
        private void LoadLanguage()
        {
            LanguageManager LanguageSwitch = new LanguageManager();
            bunifuCustomLabel_HeaderName.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_HeaderName.Tag.ToString());
            bunifuCustomLabel_VoucherName.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_VoucherName.Name);
            bunifuCustomLabel_PulishDate.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_PulishDate.Name);
            bunifuCustomLabel_ExpireDate.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_ExpireDate.Name);
            bunifuCustomLabel_Type.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Type.Name);
            bunifuCustomLabel_Quantity.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Quantity.Name);
            bunifuCustomLabel_Description.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Description.Name);
        }

        private void LoadTheme()
        {
            //Header
            panel_Header.BackColor = ThemeManager.NormalColor;
            //Background
            this.BackColor = ThemeManager.BackgroundColor;
            //Label
            bunifuCustomLabel_VoucherName.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_PulishDate.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_ExpireDate.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_Type.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_Quantity.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_Description.ForeColor = ThemeManager.ForeColor;
            //Textbox + combobox
            bunifuCustomTextbox_VoucherName.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_VoucherName.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_PulishDate.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_PulishDate.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_ExpireDate.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_ExpireDate.ForeColor = ThemeManager.ForeColor;
            numericUpDown_Quantity.BackColor = ThemeManager.BackgroundColor;
            numericUpDown_Quantity.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_Description.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_Description.ForeColor = ThemeManager.ForeColor;
            bunifuDropdown_Type.BackColor = ThemeManager.BackgroundColor;
            bunifuDropdown_Type.NomalColor = ThemeManager.BackgroundColor;
            bunifuDropdown_Type.onHoverColor = ThemeManager.FocusColor;
            bunifuDropdown_Type.ForeColor = ThemeManager.ForeColor;
            //Button
            bunifuTileButton_CreateVouchers.BackColor = ThemeManager.NormalColor;
            bunifuTileButton_CreateVouchers.color = ThemeManager.NormalColor;
            bunifuTileButton_CreateVouchers.colorActive = ThemeManager.FocusColor;
            bunifuTileButton_CreateVouchers.ForeColor = ThemeManager.ButtonForeColor;
        }
        #endregion

        private void bunifuTileButton_CreateVouchers_Click(object sender, EventArgs e)
        {
            ErrorManager.MessageDisplay("This function is not implemented", "", "Sorry. We haven't implement this function (yet)" + Environment.NewLine + "Sorry for the inconvinient");
        }
    }
}
