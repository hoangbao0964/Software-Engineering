using Project_BookCoffeeManagement.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_BookCoffeeManagement.BLL
{
    class ThreadManager
    {
        protected static LoadingScreen loadingScreen = null;

        public static void DisplayLoadingScreen()
        {
            CloseLoadingScreen();
            ThreadPool.QueueUserWorkItem((x) =>
            {
                loadingScreen = new LoadingScreen(360);
                loadingScreen.StartPosition = FormStartPosition.CenterScreen;
                loadingScreen.ShowDialog();
            });
        }

        public static void CloseLoadingScreen()
        { 
            try
            {
                loadingScreen.DialogResult = DialogResult.OK;
                loadingScreen.Close();
                loadingScreen.Dispose();
                loadingScreen = null;
            }
            catch
            { }
        }             
    }
    
}
