using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BookCoffeeManagement.Entities.People.Staffs
{
    class WarehouseManager : Staff
    {
        #region Constructors & Initialize methods
        public WarehouseManager(string address, string civilianID, string contactNumber, DateTime? dateOfBirth, string fullName, string gender, string currentPosition, double? currentSalaryPerHour, string staffID, string staffStatus, double? workingHours, string username, string password, string description, string occupation) : base(address, civilianID, contactNumber, dateOfBirth, fullName, gender, currentPosition, currentSalaryPerHour, staffID, staffStatus, workingHours, username, password, description, occupation)
        {
        }

        public WarehouseManager() : base()
        { }
        #endregion

        #region Permission
        public override bool CanCreateOrder()
        {
            return false;
        }

        public override bool CanCancelOrder()
        {
            return false;
        }

        public override bool CanUpdateOrder()
        {
            return false;
        }

        public override bool CanAddVoucher()
        {
            return false;
        }

        public override bool CanAddWishlist()
        {
            return false;
        }

        public override bool CanUpdateWishlist()
        {
            return false;
        }

        public override bool CanDeleteWishlist()
        {
            return false;
        }

        public override bool CanAddVIP()
        {
            return false;
        }

        public override bool CanUpdateVIP()
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

        public override bool CanGenerateReport()
        {
            return false;
        }

        #endregion
    }
}
