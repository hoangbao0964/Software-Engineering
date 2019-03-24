using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BookCoffeeManagement.Entities.People.Customers
{
    public class VIP : Person
    {
        #region Attributes
        protected DateTime? registerDate;
        protected DateTime endDate;
        protected string occupation;
        protected string vipID;
        protected string vipStatus;

        public DateTime? RegisterDate
        {
            get
            {
                return registerDate;
            }

            set
            {
                registerDate = value;
            }
        }
        public DateTime? EndDate
        {
            get
            {
                return endDate;
            }

            set
            {
                DateTime temp;
                if (DateTime.TryParse(value.Value.Date.ToString("d"), out temp))
                    endDate = temp;
                else
                    endDate = DateTime.Now;
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
        public string VipID
        {
            get
            {
                return vipID;
            }

            set
            {
                vipID = value;
            }
        }
        public string VipStatus
        {
            get
            {
                return vipStatus;
            }

            set
            {
                vipStatus = value;
            }
        }
        #endregion

        #region Constructors & Initialize methods
        public virtual bool Init(DateTime registerDate, DateTime endDate, string occupation, string vipID, string vipStatus)
        {
            this.registerDate = registerDate;
            this.endDate = endDate;
            this.occupation = occupation;
            this.vipID = vipID;
            this.vipStatus = vipStatus;

            return true;
        }

        public VIP(string address, string civilianID, string contactNumber, DateTime dateOfBirth, string fullName, string gender, DateTime registerDate, DateTime endDate, string occupation, string vipID, string vipStatus) : base(address, civilianID, contactNumber, dateOfBirth, fullName, gender)
        {
            Init(registerDate, endDate, occupation, vipID, vipStatus);
        }

        public VIP() : base()
        {
            Init(DateTime.Now, DateTime.Now, occupation, vipID, vipStatus);
        }
        #endregion
    }
}
