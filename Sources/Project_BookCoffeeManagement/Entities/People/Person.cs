using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BookCoffeeManagement.Entities.People
{
    public abstract class Person
    {
        #region Attributes
        protected string address;
        protected string civilianID;
        protected string contactNumber;
        protected DateTime? dateOfBirth;
        protected string fullName;
        protected string gender;

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }
        public string CivilianID
        {
            get
            {
                return civilianID;
            }

            set
            {
                civilianID = value;
            }
        }
        public string ContactNumber
        {
            get
            {
                return contactNumber;
            }

            set
            {
                contactNumber = value;
            }
        }
        public DateTime? DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }

            set
            {
                dateOfBirth = value;
            }
        }
        public string FullName
        {
            get
            {
                return fullName;
            }

            set
            {
                fullName = value;
            }
        }
        public string Gender
        {
            get
            {
                return gender;
            }

            set
            {
                gender = value;
            }
        }
        #endregion

        #region Constructors & Initialize methods
        public virtual bool Init(string address, string civilianID, string contactNumber, DateTime? dateOfBirth, string fullName, string gender)
        {
            this.address = address;
            this.civilianID = civilianID;
            this.contactNumber = contactNumber;
            this.dateOfBirth = dateOfBirth;
            this.fullName = fullName;
            this.gender = gender;

            return true;
        }

        public Person()
        {
            Init("", "", "", DateTime.Now, "", "");
        }

        public Person(string address, string civilianID, string contactNumber, DateTime? dateOfBirth, string fullName, string gender)
        {
            Init(address, civilianID, contactNumber, dateOfBirth, fullName, gender);
        }
        #endregion

        internal virtual string ValidateField()
        {
            try
            {
                long temp1 = long.Parse(CivilianID);
                if (temp1 < 0)
                    return "A civilian ID can't be a negative number";
            }
            catch
            {
                return "A civilian ID must be a number";
            }

            try
            {
                long temp1 = int.Parse(ContactNumber);
                if (temp1 < 0)
                    return "Phone number can't be a negative number";
            }
            catch
            {
                return "Phone number must be a number";
            }
            return "";
        }
    }
}
