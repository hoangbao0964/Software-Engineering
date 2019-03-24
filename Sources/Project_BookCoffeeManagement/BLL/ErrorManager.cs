using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_BookCoffeeManagement.BLL
{
    public class ErrorManager
    {
        public static void MessageDisplay(string errStr, string successMessage, string errorMessage)
        {
            if (errStr == "")
            {
                MessageBox.Show(successMessage, "Success Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(errorMessage + "\n\nError: " + errStr, "Error Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static DialogResult WarningDisplay(string warningMsg)
        {
            return MessageBox.Show(warningMsg, "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }
    }
}
