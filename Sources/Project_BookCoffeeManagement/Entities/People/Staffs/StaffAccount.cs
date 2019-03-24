using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BookCoffeeManagement.Entities.People.Staffs
{
    public class StaffAccount
    {
        #region Attributes
        protected string username;
        protected string password;

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }
        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = EncryptPassword(value);
            }
        }
        #endregion

        #region Constructor & Initialize methods
        public virtual bool Init(string username, string password)
        {
            this.Username = username;
            this.Password = password;

            return true;
        }

        public StaffAccount()
        {
            Init("", "");
        }

        public StaffAccount(string name, string pass)
        {
            Init(name, pass);
        }

        private string EncryptPassword(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            byte[] hashBytes;
            using (var algorithm = new System.Security.Cryptography.SHA512Managed())
            {
                hashBytes = algorithm.ComputeHash(bytes);
            }
            return Convert.ToBase64String(hashBytes);
         }
        #endregion
    }
}
