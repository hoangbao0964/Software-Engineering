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
using Project_BookCoffeeManagement.Entities.People.Staffs;
using Project_BookCoffeeManagement.BLL.People.Staffs;

namespace Project_BookCoffeeManagement.GUI.Input_Output_Forms.IO_forms
{
    public partial class StaffForm : FormTemplate
    {
        private string mode;
        private Staff staff;
        private StaffManager staffManager;
        private StaffAccountManager accManager;

        public StaffForm(string cmd)
        {
            InitializeComponent();
            Load(cmd);
        }

        public void Load(string cmd)
        {
            ThreadManager.DisplayLoadingScreen();
            staffManager = new StaffManager();
            accManager = new StaffAccountManager();
            switch (cmd)
            {
                case "Add": LoadAddForm(); break;
                case "Update": LoadUpdateForm(); break;
                case "View": LoadViewForm(); break;
            }
            LoadTheme();
            LoadLanguage();
            LoadRecommendData();
            if (staff != null)
                DisplayStaffInfo();
            ThreadManager.CloseLoadingScreen();
        }

        public StaffForm(string cmd, Staff staff)
        {
            InitializeComponent();
            this.staff = staff;
            Load(cmd);
        }

        private void LoadUpdateForm()
        {
            bunifuTileButton_Execute.LabelText = "Update staff";
            mode = "update";
        }

        private void LoadAddForm()
        {
            bunifuTileButton_Execute.LabelText = "Add staff";
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
            bunifuCustomTextbox_StaffID.ReadOnly = true;
            bunifuCustomTextbox_FirstName.ReadOnly = true;
            bunifuCustomTextbox_LastName.ReadOnly = true;
            bunifuCustomTextbox_DoB.ReadOnly = true;
            bunifuCustomTextbox_Gender.ReadOnly = true;
            bunifuCustomTextbox_CivilianID.ReadOnly = true;
            bunifuCustomTextbox_Occupation.ReadOnly = true;
            bunifuCustomTextbox_PhoneNumber.ReadOnly = true;
            bunifuCustomTextbox_Address.ReadOnly = true;

            bunifuCustomTextbox_Username.ReadOnly = true;
            bunifuCustomTextbox_Password.ReadOnly = true;
            bunifuDropdown_PresentPosition.Items = new string[] { staff.CurrentPosition };
            bunifuDropdown_PresentPosition.selectedIndex = 0;
            bunifuDropdown_Status.Items = new string[] { staff.StaffStatus };
            bunifuDropdown_Status.selectedIndex = 0;
            bunifuMetroTextbox_WorkingHours.Enabled = false;
            bunifuMetroTextbox_AmountTendered.Enabled = false;
            bunifuCustomTextbox_Notes.ReadOnly = true;
        }

        private void DisplayStaffInfo()
        {
            bunifuCustomTextbox_StaffID.Text = staff.StaffID;
            bunifuCustomTextbox_FirstName.Text = staff.FullName;
            bunifuCustomTextbox_LastName.Text = "";
            bunifuCustomTextbox_DoB.Text = staff.DateOfBirth.Value.Date.ToString("d"); 
            bunifuCustomTextbox_Gender.Text = staff.Gender;
            bunifuCustomTextbox_CivilianID.Text = staff.CivilianID;
            bunifuCustomTextbox_Occupation.Text = staff.Occupation;
            bunifuCustomTextbox_PhoneNumber.Text = staff.ContactNumber;
            bunifuCustomTextbox_Address.Text = staff.Address;

            bunifuCustomTextbox_Username.Text = accManager.GetUsername(staff.StaffID);

            bunifuDropdown_PresentPosition.selectedIndex = Array.IndexOf(bunifuDropdown_PresentPosition.Items, staff.CurrentPosition);
            bunifuDropdown_Status.selectedIndex = Array.IndexOf(bunifuDropdown_Status.Items, staff.StaffStatus);

            bunifuMetroTextbox_WorkingHours.Text = staff.WorkingHours.ToString();
            bunifuMetroTextbox_AmountTendered.Text = staff.CurrentSalaryPerHour.ToString();
            bunifuCustomTextbox_Notes.Text = staff.Description;
        }

        private void LoadRecommendData()
        {
            List<string> genderRecommendation = staffManager.GetGenderList();
            List<string> occupationRecommendation = staffManager.GetOccupationList();
            List<string> statusRecommendation = staffManager.GetStaffStatusList();
            List<string> positionRecommedation = staffManager.GetStaffPositionList();

            AutoCompleteStringCollection collection_gender = new AutoCompleteStringCollection();
            collection_gender.AddRange(genderRecommendation.ToArray());
            this.bunifuCustomTextbox_Gender.AutoCompleteCustomSource = collection_gender;

            AutoCompleteStringCollection collection_occupation = new AutoCompleteStringCollection();
            collection_occupation.AddRange(occupationRecommendation.ToArray());
            this.bunifuCustomTextbox_Occupation.AutoCompleteCustomSource = collection_occupation;

            bunifuDropdown_Status.Items = statusRecommendation.ToArray();
            bunifuDropdown_PresentPosition.Items = positionRecommedation.ToArray();
        }

        private void bunifuTileButton_Execute_Click(object sender, EventArgs e)
        {
            string err = "";
            if (mode == "view")
            {
                this.Close();
                return;
            }
            ThreadManager.DisplayLoadingScreen();
            Staff newStaff = new Staff();
            try
            {
                newStaff.StaffID = bunifuCustomTextbox_StaffID.Text;
                newStaff.FullName = bunifuCustomTextbox_FirstName.Text;
                newStaff.DateOfBirth = Convert.ToDateTime(bunifuCustomTextbox_DoB.Text);
                newStaff.Gender = bunifuCustomTextbox_Gender.Text;
                newStaff.CivilianID = bunifuCustomTextbox_CivilianID.Text;
                newStaff.Occupation = bunifuCustomTextbox_Occupation.Text;
                newStaff.ContactNumber = bunifuCustomTextbox_PhoneNumber.Text;
                newStaff.Address = bunifuCustomTextbox_Address.Text;
                newStaff.CurrentPosition = bunifuDropdown_PresentPosition.selectedValue;
                newStaff.CurrentSalaryPerHour = double.Parse(bunifuMetroTextbox_AmountTendered.Text);
                newStaff.Description = bunifuCustomTextbox_Notes.Text;
                newStaff.StaffStatus = bunifuDropdown_Status.selectedValue;
            }
            catch (Exception ex)
            {
                ThreadManager.CloseLoadingScreen();
                ErrorManager.MessageDisplay(ex.Message, "", "Extract data failed");
                return;
            }

            err = newStaff.ValidateField();
            if (err != "")
            {
                ThreadManager.CloseLoadingScreen();
                ErrorManager.MessageDisplay(err, "", "Incorrect values");
                return;
            }


            err = staffManager.AddOrUpdateStaff(newStaff);
            if (err != "")
            {
                ThreadManager.CloseLoadingScreen();
                ErrorManager.MessageDisplay(err, "", "Add/Update staff falied");
                return;
            }

            string staffID = "";
            if (mode == "update")
                staffID = bunifuCustomTextbox_StaffID.Text;
            else if (mode == "add")
                staffID = staffManager.GetStaffIDFromCivilianID(newStaff.CivilianID);

            if (bunifuCustomTextbox_Username.Text == "" || bunifuCustomTextbox_Password.Text == "")
            {
                ErrorManager.MessageDisplay("Require data not input", "", "You must provide a username & a password");
                return;
            }


            err = accManager.AddOrUpdateAccount(staffID, bunifuCustomTextbox_Username.Text, bunifuCustomTextbox_Password.Text);
            ThreadManager.CloseLoadingScreen();
            ErrorManager.MessageDisplay(err, "Add/Update staff successfully", "Add/Update staff falied");

            if (err == "")
                this.Close();
        }

        #region Load Theme & Language
        private void LoadLanguage()
        {
            LanguageManager LanguageSwitch = new LanguageManager();
            bunifuCustomLabel_HeaderName.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_HeaderName.Tag.ToString());
            groupBox_PersonalINfo.Text = LanguageSwitch.ChangeName(groupBox_PersonalINfo.Name);
            groupBox_WorkingInfo.Text = LanguageSwitch.ChangeName(groupBox_WorkingInfo.Name);
            bunifuCustomLabel_StaffID.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_StaffID.Name);
            bunifuCustomLabel_FirstName.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_FirstName.Name);
            bunifuCustomLabel_LastName.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_LastName.Name);
            bunifuCustomLabel_DayOfBirth.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_DayOfBirth.Name);
            bunifuCustomLabel_Gender.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Gender.Name);
            bunifuCustomLabel_CivilianID.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_CivilianID.Name);
            bunifuCustomLabel_Occupation.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Occupation.Name);
            bunifuCustomLabel_PhoneNumber.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_PhoneNumber.Name);
            bunifuCustomLabel_Address.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Address.Name);
            bunifuCustomLabel_Username.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Username.Name);
            bunifuCustomLabel_Password.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Password.Name);
            bunifuCustomLabel_PresentPosition.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_PresentPosition.Name);
            bunifuCustomLabel_Status.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Status.Name);
            bunifuCustomLabel_TotalWorkingHours.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_TotalWorkingHours.Name);
            bunifuCustomLabel_CurrentSalary.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_CurrentSalary.Name);
            bunifuCustomLabel_Notes.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Notes.Name);
        }

        private void LoadTheme()
        {
            panel_Header.BackColor = ThemeManager.NormalColor;
            //Group box color
            groupBox_PersonalINfo.BackColor = ThemeManager.BackgroundColor;
            groupBox_PersonalINfo.ForeColor = ThemeManager.ForeColor;
            groupBox_WorkingInfo.BackColor = ThemeManager.BackgroundColor;
            groupBox_WorkingInfo.ForeColor = ThemeManager.ForeColor;
            //Label color
            bunifuCustomLabel_StaffID.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_FirstName.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_LastName.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_DayOfBirth.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_Gender.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_CivilianID.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_Occupation.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_PhoneNumber.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_Address.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_Username.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_Password.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_PresentPosition.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_TotalWorkingHours.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_CurrentSalary.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_Notes.ForeColor = ThemeManager.ForeColor;
            //Textbox color
            bunifuCustomTextbox_StaffID.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_StaffID.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_FirstName.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_FirstName.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_LastName.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_LastName.ForeColor = ThemeManager.ForeColor;
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
            bunifuCustomTextbox_Username.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_Username.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_Password.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_Password.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_Notes.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_Notes.ForeColor = ThemeManager.ForeColor;
            bunifuMetroTextbox_WorkingHours.BackColor = ThemeManager.BackgroundColor;
            bunifuMetroTextbox_WorkingHours.BorderColorFocused = ThemeManager.NormalColor;
            bunifuMetroTextbox_WorkingHours.BorderColorIdle = ThemeManager.NormalColor;
            bunifuMetroTextbox_WorkingHours.BorderColorMouseHover = ThemeManager.MenuColor;
            bunifuMetroTextbox_WorkingHours.ForeColor = ThemeManager.ForeColor;
            bunifuMetroTextbox_AmountTendered.BackColor = ThemeManager.BackgroundColor;
            bunifuMetroTextbox_AmountTendered.BorderColorFocused = ThemeManager.NormalColor;
            bunifuMetroTextbox_AmountTendered.BorderColorIdle = ThemeManager.NormalColor;
            bunifuMetroTextbox_AmountTendered.BorderColorMouseHover = ThemeManager.MenuColor;
            bunifuMetroTextbox_AmountTendered.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_Gender.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_Gender.BackColor = ThemeManager.BackgroundColor;
            //Combobox color
            bunifuDropdown_PresentPosition.NomalColor = ThemeManager.BackgroundColor;
            bunifuDropdown_PresentPosition.onHoverColor = ThemeManager.FocusColor;
            bunifuDropdown_PresentPosition.ForeColor = ThemeManager.ForeColor;
            bunifuDropdown_Status.NomalColor = ThemeManager.BackgroundColor;
            bunifuDropdown_Status.onHoverColor = ThemeManager.FocusColor;
            bunifuDropdown_Status.ForeColor = ThemeManager.ForeColor;
            //Button color
            bunifuTileButton_Execute.BackColor = ThemeManager.NormalColor;
            bunifuTileButton_Execute.color = ThemeManager.NormalColor;
            bunifuTileButton_Execute.colorActive = ThemeManager.FocusColor;
            bunifuTileButton_Execute.ForeColor = ThemeManager.ButtonForeColor;
        }
        #endregion
    }
}
