using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BookCoffeeManagement.Entities.People.Staffs
{
    public class Cashier : Staff
    {
       
        #region Constructors & Initialize methods
        public Cashier(string address, string civilianID, string contactNumber, DateTime? dateOfBirth, string fullName, string gender, string currentPosition, double? currentSalaryPerHour, string staffID, string staffStatus, double? workingHours, string username, string password, string description, string occupation) : base(address, civilianID, contactNumber, dateOfBirth, fullName, gender, currentPosition, currentSalaryPerHour, staffID, staffStatus, workingHours, username, password, description, occupation)
        {
        }

        public Cashier() : base ()
        {
        }
        #endregion

        #region Permission 
        public override bool CanAddVoucher()
        {
            return false;
        }

        public override bool CanAddMenu()
        {
            return false;
        }

        public override bool CanUpdateMenu()
        {
            return false;
        }

        public override bool CanDeleteMenu()
        {
            return false;
        }

        public override bool CanAddBook()
        {
            return false;
        }

        public override bool CanUpdateBook()
        {
            return false;
        }

        public override bool CanDeleteBook()
        {
            return false;
        }

        public override bool CanViewAllStaff()
        {
            return false;
        }

        public override bool CanUpdateStaff()
        {
            return false;
        }

        public override bool CanCreateSchedule()
        {
            return false;
        }

        public override bool CanCreateStockOrder()
        {
            return false;
        }

        public override bool CanAddStockItem()
        {
            return false;
        }

        public override bool CanUpdateStockItem()
        {
            return false;
        }

        public override bool CanGenerateReport()
        {
            return false;
        }

        #endregion
    }
}
