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
using Project_BookCoffeeManagement.Entities.People.Customers;
using Project_BookCoffeeManagement.BLL.People.Customers;

namespace Project_BookCoffeeManagement.GUI.Input_Output_Forms.IO_forms
{
    public partial class VIPForm : FormTemplate
    {
        private VIP customer = null;
        private VIPManager manager;
        protected string mode = "";

        public VIPForm(string cmd)
        {
            InitializeComponent();
            Load(cmd);

        }

        public VIPForm(string cmd, VIP customer)
        {
            InitializeComponent();
            this.customer = customer;            
            Load(cmd);
            DisplayVIPDataToScreen();
        }

        private void Load(string cmd)
        {
            ThreadManager.DisplayLoadingScreen();
            manager = new VIPManager();
            switch (cmd)
            {
                case "Add": LoadAddForm(); break;
                case "Update": LoadUpdateForm(); break;
                case "View": LoadViewForm(); break;
            }
            LoadTheme();
            LoadLanguage();
            LoadRecommendData();
            ThreadManager.CloseLoadingScreen();
        }

        private void LoadRecommendData()
        {
            List<string> genderRecommendation = manager.GetGenderList();
            List<string> occupationRecommendation = manager.GetOccupationList();

            AutoCompleteStringCollection collection_gender = new AutoCompleteStringCollection();
            collection_gender.AddRange(genderRecommendation.ToArray());
            this.bunifuCustomTextbox_Gender.AutoCompleteCustomSource = collection_gender;

            AutoCompleteStringCollection collection_occupation = new AutoCompleteStringCollection();
            collection_occupation.AddRange(occupationRecommendation.ToArray());
            this.bunifuCustomTextbox_Occupation.AutoCompleteCustomSource = collection_occupation;
        }

        private void DisplayVIPDataToScreen()
        {
            
            if (customer != null)
            {
                bunifuCustomTextbox_VipID.Text = customer.VipID;
                bunifuCustomTextbox_FullName.Text = customer.FullName;
                bunifuCustomTextbox_DoB.Text = customer.DateOfBirth.Value.Date.ToString("d");
                bunifuCustomTextbox_Gender.Text = customer.Gender;
                bunifuCustomTextbox_CivilianID.Text = customer.CivilianID;
                bunifuCustomTextbox_Occupation.Text = customer.Occupation;
                bunifuCustomTextbox_PhoneNumber.Text = customer.ContactNumber;
                bunifuCustomTextbox_Address.Text = customer.Address;
                if (customer.EndDate == null)
                    customer.EndDate = DateTime.Now;
                bunifuCustomTextbox_Membership.Text = (customer.EndDate - DateTime.Now).Value.Days.ToString() + " days";
            }
            
        }

        private void LoadUpdateForm()
        {
            bunifuTileButton_Execute.LabelText = "Update VIP";
            mode = "update";
        }

        private void LoadAddForm()
        {
            bunifuTileButton_Execute.LabelText = "Add VIP";
            mode = "add";
            bunifuCustomTextbox_CivilianID.Enabled = true;
        }

        private void LoadViewForm()
        {
            bunifuTileButton_Execute.LabelText = "OK";
            mode = "view";
            DisableFields();
        }

        private void DisableFields()
        {
            bunifuCustomTextbox_VipID.ReadOnly = true;
            bunifuCustomTextbox_FullName.ReadOnly = true;
            bunifuCustomTextbox_DoB.ReadOnly = true;
            bunifuCustomTextbox_Gender.ReadOnly = true;
            bunifuCustomTextbox_CivilianID.ReadOnly = true;
            bunifuCustomTextbox_Occupation.ReadOnly = true;
            bunifuCustomTextbox_PhoneNumber.ReadOnly = true;
            bunifuCustomTextbox_Address.ReadOnly = true;
            bunifuCustomTextbox_Membership.ReadOnly = true;
        }

        private void bunifuTileButton_Execute_Click(object sender, EventArgs e)
        {
            if (mode == "view")
            {
                this.Close();
                return;
            }

            ThreadManager.DisplayLoadingScreen();
            VIP newVIP = new VIP();
            try
            {
                Random rnd = new Random();
                newVIP.VipID = rnd.Next().ToString();   // Dummy init
                newVIP.FullName = bunifuCustomTextbox_FullName.Text;
                newVIP.DateOfBirth = Convert.ToDateTime(bunifuCustomTextbox_DoB.Text).Date;
                newVIP.Gender = bunifuCustomTextbox_Gender.Text;
                newVIP.CivilianID = bunifuCustomTextbox_CivilianID.Text;
                newVIP.Occupation = bunifuCustomTextbox_Occupation.Text;
                newVIP.ContactNumber = bunifuCustomTextbox_PhoneNumber.Text;
                newVIP.Address = bunifuCustomTextbox_Address.Text;
            }
            catch (Exception ex)
            {
                ThreadManager.CloseLoadingScreen();
                ErrorManager.MessageDisplay(ex.Message, "", "Error: Can't get data from fields");
                return;
            }

            string err = "";
            if (mode != "delete")
                err = newVIP.ValidateField();
            if (err != "")
            {
                ThreadManager.CloseLoadingScreen();
                ErrorManager.MessageDisplay(err, "", "Incorrect values");
                return;
            }

            err = manager.AddOrUpdateAVIP(newVIP);
            ThreadManager.CloseLoadingScreen();
            ErrorManager.MessageDisplay(err, "Add/Update a VIP successfully", "Failed to add/update a VIP");

            if (err == "")
                this.Close();
        }

        private void VIPForm_Load(object sender, EventArgs e)
        {

        }

        #region Load Theme & Language
        private void LoadLanguage()
        {
            LanguageManager LanguageSwitch = new LanguageManager();
            bunifuCustomLabel_HeaderName.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_HeaderName.Tag.ToString());
            bunifuCustomLabel_VipID.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_VipID.Name);
            bunifuCustomLabel_Membership.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Membership.Name);
            bunifuCustomLabel_FullName.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_FullName.Name);
            bunifuCustomLabel_DayOfBirth.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_DayOfBirth.Name);
            bunifuCustomLabel_Gender.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Gender.Name);
            bunifuCustomLabel_CivilianID.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_CivilianID.Name);
            bunifuCustomLabel_Occupation.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Occupation.Name);
            bunifuCustomLabel_PhoneNumber.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_PhoneNumber.Name);
            bunifuCustomLabel_Address.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Address.Name);
        }

        private void LoadTheme()
        {
            //Header
            panel_Header.BackColor = ThemeManager.NormalColor;
            //Background
            this.BackColor = ThemeManager.BackgroundColor;
            //Label
            bunifuCustomLabel_VipID.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_Membership.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_FullName.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_DayOfBirth.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_Gender.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_CivilianID.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_Occupation.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_PhoneNumber.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_Address.ForeColor = ThemeManager.ForeColor;
            //Textbox
            bunifuCustomTextbox_VipID.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_VipID.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_Membership.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_Membership.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_FullName.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_FullName.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_DoB.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_DoB.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_CivilianID.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_CivilianID.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_Occupation.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_Occupation.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_PhoneNumber.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_PhoneNumber.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_Address.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_Address.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_Gender.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_Gender.ForeColor = ThemeManager.ForeColor;
            //Button
            bunifuTileButton_Execute.BackColor = ThemeManager.NormalColor;
            bunifuTileButton_Execute.color = ThemeManager.NormalColor;
            bunifuTileButton_Execute.colorActive = ThemeManager.FocusColor;
            bunifuTileButton_Execute.ForeColor = ThemeManager.ButtonForeColor;
        }

        #endregion

    }
}
