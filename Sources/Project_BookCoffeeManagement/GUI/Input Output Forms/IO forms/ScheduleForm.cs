using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ns1;
using Project_BookCoffeeManagement.GUI.Input_Output_Forms.Collector_forms;
using Project_BookCoffeeManagement.BLL.Schedule;
using Project_BookCoffeeManagement.Entities.Schedule;
using Project_BookCoffeeManagement.Entities.People.Staffs;
using Project_BookCoffeeManagement.BLL;

namespace Project_BookCoffeeManagement.GUI.Input_Output_Forms.IO_forms
{
    public partial class ScheduleForm : FormTemplate
    {
        string UserRequest; //Edit schedule | View only
        DateTime currentDate = DateTime.Today;
        DateTime currentViewDate;
        private ScheduleManager manager;
        private Schedule savedSchedule;
        private List<WorkingShift> newSchedule;

        public ScheduleForm(string cmd)
        {
            InitializeComponent();
            ThreadManager.DisplayLoadingScreen();
            Load(cmd);
            ThreadManager.CloseLoadingScreen();
        }

        private void Load(string cmd)
        {
            manager = new ScheduleManager();
            savedSchedule = new Schedule();
            newSchedule = new List<WorkingShift>();
            UserRequest = cmd;
            DisplayWeek_StartDate_EndDate(currentDate);
            panel_Header.Focus();
            bunifuMetroTextbox_CurrentWeek.Enabled = false;
            if(UserRequest == "View only")
            {
                bunifuThinButton_SaveChanges.Enabled = false;
                bunifuThinButton_SaveChanges.Visible = false;
                bunifuMetroTextbox_CurrentWeek.Location = new Point(251, 60);
            }
            LoadTheme();
            LoadLanguage();
        }

        #region Handling shifts
        private void bunifuCustomLabel_Mon_S1_Click(object sender, EventArgs e)
        {
            CallCollector(bunifuCustomLabel_Mon_S1);
        }

        private void bunifuCustomLabel_Mon_S2_Click(object sender, EventArgs e)
        {
            CallCollector(bunifuCustomLabel_Mon_S2);
        }

        private void bunifuCustomLabel_Tue_S1_Click(object sender, EventArgs e)
        {
            CallCollector(bunifuCustomLabel_Tue_S1);
        }

        private void bunifuCustomLabel_Tue_S2_Click(object sender, EventArgs e)
        {
            CallCollector(bunifuCustomLabel_Tue_S2);
        }

        private void bunifuCustomLabel_Wed_S1_Click(object sender, EventArgs e)
        {
            CallCollector(bunifuCustomLabel_Wed_S1);
        }

        private void bunifuCustomLabel_Wed_S2_Click(object sender, EventArgs e)
        {
            CallCollector(bunifuCustomLabel_Wed_S2);
        }

        private void bunifuCustomLabel_Thu_S1_Click(object sender, EventArgs e)
        {
            CallCollector(bunifuCustomLabel_Thu_S1);
        }

        private void bunifuCustomLabel_Thu_S2_Click(object sender, EventArgs e)
        {
            CallCollector(bunifuCustomLabel_Thu_S2);
        }

        private void bunifuCustomLabel_Fri_S1_Click(object sender, EventArgs e)
        {
            CallCollector(bunifuCustomLabel_Fri_S1);
        }

        private void bunifuCustomLabel_Fri_S2_Click(object sender, EventArgs e)
        {
            CallCollector(bunifuCustomLabel_Fri_S2);
        }

        private void bunifuCustomLabel_Sat_S1_Click(object sender, EventArgs e)
        {
            CallCollector(bunifuCustomLabel_Sat_S1);
        }

        private void bunifuCustomLabel_Sat_S2_Click(object sender, EventArgs e)
        {
            CallCollector(bunifuCustomLabel_Sat_S2);
        }

        private void bunifuCustomLabel_Sun_S1_Click(object sender, EventArgs e)
        {
            CallCollector(bunifuCustomLabel_Sun_S1);
        }

        private void bunifuCustomLabel_Sun_S2_Click(object sender, EventArgs e)
        {
            CallCollector(bunifuCustomLabel_Sun_S2);
        }
        #endregion

        private void CallCollector(BunifuCustomLabel targetLabel)
        {
            if (UserRequest == "Edit schedule")
            {
                Select_Staff_Form CallForm = new Select_Staff_Form();
                CallForm.ShowDialog();
                string[] field = targetLabel.Name.Split('_');

                if (field.Count<string>() < 3)
                    ErrorManager.MessageDisplay("Can't extract lablel name. Make sure the label name is in correct format", "", "Get information failed");
                DateTime GetDay = currentViewDate;
                int shiftNum = 0;
                switch (field[1])
                {
                    case "Mon":
                        GetDay = currentViewDate;
                        break;
                    case "Tue":
                        GetDay = currentViewDate.AddDays(1);
                        break;
                    case "Wed":
                        GetDay = currentViewDate.AddDays(2);
                        break;
                    case "Thu":
                        GetDay = currentViewDate.AddDays(3);
                        break;
                    case "Fri":
                        GetDay = currentViewDate.AddDays(4);
                        break;
                    case "Sat":
                        GetDay = currentViewDate.AddDays(5);
                        break;
                    case "Sun":
                        GetDay = currentViewDate.AddDays(6);
                        break;
                }
                switch (field[2])
                {
                    case "S1":
                        shiftNum = 1;
                        break;
                    case "S2":
                        shiftNum = 2;
                        break;
                }

                WorkingShift data = new WorkingShift(GetDay, GetDay, shiftNum);
                foreach (Staff staff in CallForm.selectedStaff)
                    data.AddWorkingStaff(staff);

                newSchedule.Add(data);

                FormatDataInLabel(data, targetLabel);
            }
        }

        private void DisplayWeek_StartDate_EndDate(DateTime InputDate)
        {       
            DateTime startDate = InputDate.AddDays(-(int)InputDate.DayOfWeek + 1);
            DateTime endDate = InputDate.AddDays(7 - (int)InputDate.DayOfWeek);
            currentViewDate = startDate;
            bunifuMetroTextbox_CurrentWeek.Text = startDate.Date.ToString("dd/MM/yyyy") + " - " + endDate.Date.ToString("dd/MM/yyyy");
            DisplaySchedule(startDate, endDate);
        }

        #region Handling Previous/Next weeks
        private void bunifuTileButton_NextWeek_Click(object sender, EventArgs e)
        {
            if (newSchedule.Count == 0 || ErrorManager.WarningDisplay("Unsaved data will be lost." + Environment.NewLine + "Do you want to continue?") == DialogResult.OK)
            {
                ThreadManager.DisplayLoadingScreen();
                currentDate = currentDate.AddDays(7);
                DisplayWeek_StartDate_EndDate(currentDate);
                newSchedule = new List<WorkingShift>();
                ThreadManager.CloseLoadingScreen();
            }
            
            
        }

        private void bunifuTileButton_PreviousWeek_Click(object sender, EventArgs e)
        {
            if (newSchedule.Count == 0 || ErrorManager.WarningDisplay("Unsaved data will be lost." + Environment.NewLine + "Do you want to continue?") == DialogResult.OK)
            {
                ThreadManager.DisplayLoadingScreen();
                currentDate = currentDate.AddDays(-7);
                DisplayWeek_StartDate_EndDate(currentDate);
                newSchedule = new List<WorkingShift>();
                ThreadManager.CloseLoadingScreen();
            }
        }


        #endregion

        private void DisplaySchedule(DateTime startDate, DateTime endDate)
        {  
            for (DateTime date = startDate; DateTime.Compare(date, endDate) <= 0; date = date.AddDays(1))
                DisplaySchedule(date);
        }

        private void DisplaySchedule(DateTime date)
        {
            BunifuCustomLabel targer_S1 = null;
            BunifuCustomLabel target_S2 = null;
            switch (date.DayOfWeek)
            {
                case (DayOfWeek.Monday):
                    targer_S1 = bunifuCustomLabel_Mon_S1;
                    target_S2 = bunifuCustomLabel_Mon_S2;
                    break;
                case (DayOfWeek.Tuesday):
                    targer_S1 = bunifuCustomLabel_Tue_S1;
                    target_S2 = bunifuCustomLabel_Tue_S2;
                    break;
                case (DayOfWeek.Wednesday):
                    targer_S1 = bunifuCustomLabel_Wed_S1;
                    target_S2 = bunifuCustomLabel_Wed_S2;
                    break;
                case (DayOfWeek.Thursday):
                    targer_S1 = bunifuCustomLabel_Thu_S1;
                    target_S2 = bunifuCustomLabel_Thu_S2;
                    break;
                case (DayOfWeek.Friday):
                    targer_S1 = bunifuCustomLabel_Fri_S1;
                    target_S2 = bunifuCustomLabel_Fri_S2;
                    break;
                case (DayOfWeek.Saturday):
                    targer_S1 = bunifuCustomLabel_Sat_S1;
                    target_S2 = bunifuCustomLabel_Sat_S2;
                    break;
                case (DayOfWeek.Sunday):
                    targer_S1 = bunifuCustomLabel_Sun_S1;
                    target_S2 = bunifuCustomLabel_Sun_S2;
                    break;
            }

            if (savedSchedule.GetSchedule(date) == null)
            {
                DailySchedule schedule = manager.GetSchedule(date);
                savedSchedule.AddSchedule(schedule);
                FormatDataInLabel(schedule.GetWorkingShift(1), targer_S1);
                FormatDataInLabel(schedule.GetWorkingShift(2), target_S2);
            }
            else
            {
                FormatDataInLabel(savedSchedule.GetSchedule(date).GetWorkingShift(1), targer_S1);
                FormatDataInLabel(savedSchedule.GetSchedule(date).GetWorkingShift(2), target_S2);
            }
            
        }

        private void FormatDataInLabel(WorkingShift workingShift, BunifuCustomLabel target)
        {
            string printData = "";
            if (workingShift == null)
            {
                target.Text = "(No data)";
                return;
            }
            foreach (Staff staff in workingShift.WorkingStaff.Values)
                printData += staff.FullName + " (" + staff.CurrentPosition + ")" + Environment.NewLine;

            target.Text = printData;
        }

        private void bunifuThinButton_SaveChanges_Click(object sender, EventArgs e)
        {
            ThreadManager.DisplayLoadingScreen();
            string err = manager.AddOrUpdateSchedule(newSchedule);
            ErrorManager.MessageDisplay(err, "Add schedules completed", "Add schedules failed");
            if (err == "")
                this.Close();
            ThreadManager.CloseLoadingScreen();
        }

        #region Load Theme & Language
        private void LoadLanguage()
        {
            LanguageManager LanguageSwitch = new LanguageManager();
            bunifuCustomLabel_HeaderName.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_HeaderName.Tag.ToString());
            bunifuTileButton_PreviousWeek.LabelText = LanguageSwitch.ChangeName(bunifuTileButton_PreviousWeek.Name);
            bunifuTileButton_NextWeek.LabelText = LanguageSwitch.ChangeName(bunifuTileButton_NextWeek.Name);
            bunifuThinButton_SaveChanges.ButtonText = LanguageSwitch.ChangeName(bunifuThinButton_SaveChanges.Name);
            bunifuCustomLabel_Monday.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Monday.Name);
            bunifuCustomLabel_Tuesday.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Tuesday.Name);
            bunifuCustomLabel_Wednesday.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Wednesday.Name);
            bunifuCustomLabel_Thusday.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Thusday.Name);
            bunifuCustomLabel_Friday.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Friday.Name);
            bunifuCustomLabel_Saturday.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Saturday.Name);
            bunifuCustomLabel_Sunday.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Sunday.Name);
        }

        private void LoadTheme()
        {
            panel_Header.BackColor = ThemeManager.NormalColor;
            bunifuTileButton_PreviousWeek.color = ThemeManager.NormalColor;
            bunifuTileButton_PreviousWeek.BackColor = ThemeManager.NormalColor;
            bunifuTileButton_PreviousWeek.colorActive = ThemeManager.FocusColor;
            bunifuTileButton_PreviousWeek.ForeColor = ThemeManager.ButtonForeColor;
            bunifuTileButton_NextWeek.color = ThemeManager.NormalColor;
            bunifuTileButton_NextWeek.BackColor = ThemeManager.NormalColor;
            bunifuTileButton_NextWeek.colorActive = ThemeManager.FocusColor;
            bunifuTileButton_NextWeek.ForeColor = ThemeManager.ButtonForeColor;
            bunifuThinButton_SaveChanges.ActiveFillColor = ThemeManager.FocusColor;
            bunifuThinButton_SaveChanges.ActiveLineColor = ThemeManager.FocusColor;
            bunifuThinButton_SaveChanges.ActiveForecolor = ThemeManager.ButtonForeColor;
            bunifuThinButton_SaveChanges.IdleFillColor = ThemeManager.NormalColor;
        }
        #endregion
    }
}
