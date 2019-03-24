using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BookCoffeeManagement.Entities.People.Staffs
{
    public class Staff : Person
    {
        #region Attributes
        protected string currentPosition;
        protected double? currentSalaryPerHour;
        protected string staffID;
        protected string staffStatus;
        protected double? workingHours;
        protected StaffAccount accountInfo;
        protected string description;
        protected string occupation;

        public string CurrentPosition
        {
            get
            {
                return currentPosition;
            }

            set
            {
                currentPosition = value;
            }
        }
        public double? CurrentSalaryPerHour
        {
            get
            {
                return currentSalaryPerHour;
            }

            set
            {
                currentSalaryPerHour = value;
            }
        }
        public string StaffID
        {
            get
            {
                return staffID;
            }

            set
            {
                staffID = value;
            }
        }
        public string StaffStatus
        {
            get
            {
                return staffStatus;
            }

            set
            {
                staffStatus = value;
            }
        }
        public double? WorkingHours
        {
            get
            {
                return workingHours;
            }

            set
            {
                workingHours = value;
            }
        }
        protected StaffAccount AccountInfo
        {
            get
            {
                return accountInfo;
            }

            set
            {
                accountInfo = value;
            }
        }
        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }
        public string Occupation
        {
            get
            {
                return occupation;
            }

            set
            {
                occupation = value;
            }
        }
        #endregion

        #region Constructors & Initialize methods
        public virtual bool Init(string currentPosition, double? currentSalaryPerHour, string staffID, string staffStatus, double? workingHours, string description, string occupation)
        {
            this.currentPosition = currentPosition;
            this.currentSalaryPerHour = currentSalaryPerHour;
            this.staffID = staffID;
            this.staffStatus = staffStatus;
            this.workingHours = workingHours;
            this.Occupation = occupation;
            this.Description = description;

            accountInfo = new StaffAccount();

            return true;
        }

        public Staff(string address, string civilianID, string contactNumber, DateTime? dateOfBirth, string fullName, string gender, string currentPosition, double? currentSalaryPerHour, string staffID, string staffStatus, double? workingHours, string username, string password, string description, string occupation) : base(address, civilianID, contactNumber, dateOfBirth, fullName, gender)
        {
            Init(currentPosition, currentSalaryPerHour, staffID, staffStatus, workingHours, description, occupation);
            AccountInfo.Init(username, password);
        }

        public Staff() : base()
        {
            Init("", 0, "", "", 0, "", "");
        }
        #endregion

        public StaffAccount GetAccountInfo()
        {
            return accountInfo;
        }

        public bool SetAccountInfo(StaffAccount account)
        {
            accountInfo = account;
            return true;
        }

        #region Permission
        public virtual bool CanCreateOrder()
        {
            return true;
        }

        public virtual bool CanCancelOrder()
        {
            return true;
        }

        public virtual bool CanUpdateOrder()
        {
            return true;
        }

        public virtual bool CanAddVoucher()
        {
            return true;
        }

        public virtual bool CanAddMenu()
        {
            return true;
        }

        public virtual bool CanUpdateMenu()
        {
            return true;
        }

        public virtual bool CanDeleteMenu()
        {
            return true;
        }

        public virtual bool CanAddBook()
        {
            return true;
        }

        public virtual bool CanUpdateBook()
        {
            return true;
        }

        public virtual bool CanDeleteBook()
        {
            return true;
        }

        public virtual bool CanAddWishlist()
        {
            return true;
        }

        public virtual bool CanUpdateWishlist()
        {
            return true;
        }

        public virtual bool CanDeleteWishlist()
        {
            return true;
        }

        public virtual bool CanAddVIP()
        {
            return true;
        }

        public virtual bool CanUpdateVIP()
        {
            return true;
        }

        public virtual bool CanViewAllStaff()
        {
            return true;
        }

        public virtual bool CanUpdateStaff()
        {
            return true;
        }

        public virtual bool CanCreateSchedule()
        {
            return true;
        }

        public virtual bool CanCreateStockOrder()
        {
            return true;
        }

        public virtual bool CanAddStockItem()
        {
            return true;
        }

        public virtual bool CanUpdateStockItem()
        {
            return true;
        }

        public virtual bool CanGenerateReport()
        {
            return true;
        }


        #endregion
    }
}
