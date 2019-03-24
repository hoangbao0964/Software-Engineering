using Project_BookCoffeeManagement.BLL;
using Project_BookCoffeeManagement.BLL.People.Staffs;
using Project_BookCoffeeManagement.Entities.People.Staffs;
using Project_BookCoffeeManagement.GUI.Input_Output_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_BookCoffeeManagement.GUI
{
    public partial class LoginForm : FormTemplate
    {
        private StaffAccountManager accManager;

        public LoginForm()
        {
            InitializeComponent();
            accManager = new StaffAccountManager();
        }

        private void SignIn()
        {
            StaffAccount account = new StaffAccount(bunifuCustomTextbox_Username.Text, bunifuCustomTextbox_Password.Text);

            ThreadManager.DisplayLoadingScreen();                   
            bool correctInfo = accManager.IsCorrectLoginInfo(account);
            if (correctInfo)
            {
                Form CallMainActive = new MainActive(accManager.GetStaffID(account.Username));               
                this.Hide();
                CallMainActive.ShowDialog();
                if (CallMainActive.DialogResult == DialogResult.OK)
                {
                    this.bunifuCustomTextbox_Password.Text = "";
                    this.Show();
                    this.bunifuCustomTextbox_Username.Focus();
                }
            }
            else
            {
                ErrorManager.MessageDisplay("Incorrect data", "", "Wrong username or passsword.");
            }
        }
        private void bunifuThinButton_Login_Click(object sender, EventArgs e)
        {
            SignIn();
        }

        private void bunifuCustomLabel_ForgotPassword_Click(object sender, EventArgs e)
        {
            /*
             * Trước mắt quăng cái thông báo thôi. Về sau được rảnh thì cho gửi email luôn :v 
             */
            string msg = "Contact with your managers to get new password.";
            msg += Environment.NewLine + "++  Mr.Nam:     091-343-2279";
            msg += Environment.NewLine + "++  Miss.Linh:   0123-741-2202";
            MessageBox.Show(msg, "Forgot password...", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bunifuCustomTextbox_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SignIn();
            }
        }

        private void bunifuCustomTextbox_Username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SignIn();
            }
        }
    }
}
