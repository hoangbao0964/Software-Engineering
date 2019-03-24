using Project_BookCoffeeManagement.GUI.Input_Output_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_BookCoffeeManagement.GUI
{
    public partial class LoadingScreen : FormTemplate
    {
        private int timer = 0; //số giây * 66 = timer, gần bằng thôi chứ ko chuẩn 100% nhé.
        private bool begin = true;
        public LoadingScreen(int timer)
        {
            InitializeComponent();
            bunifuCircleProgressbar_LoadingScreen.MaxValue = 100;
            bunifuCircleProgressbar_LoadingScreen.Value = -85;
            bunifuCircleProgressbar_LoadingScreen.Value = 85;
            this.timer = timer * 66;
        }

        private void LoadingScreen_Load(object sender, EventArgs e)
        {
            begin = false;
        }

        private void bunifuCircleProgressbar_LoadingScreen_ProgressChanged(object sender, EventArgs e)
        {
            if (begin == false)
            {
                if (this.timer <= 0)
                    this.Close();
                timer--;
            }
        }
    }
}
