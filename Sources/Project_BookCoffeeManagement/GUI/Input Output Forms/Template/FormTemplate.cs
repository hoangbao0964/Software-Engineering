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
    public partial class FormTemplate : Form
    {
        public FormTemplate()
        {
            InitializeComponent();
            panel_Header.BackColor = ThemeManager.NormalColor;
            panel_Header.ForeColor = ThemeManager.ButtonForeColor;
            this.BackColor = ThemeManager.BackgroundColor;
        }

        private void bunifuImageButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
