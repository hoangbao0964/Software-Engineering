using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_BookCoffeeManagement.Entities.People.Staffs;
using System.Data.Linq;

namespace Project_BookCoffeeManagement.BLL.People.Staffs
{
    class StaffAccountManager : Manager
    {
        #region Get Table
        protected Table<DAL.StaffAccount> GetStaffAccountTable()
        {
            return db.GetTable<DAL.StaffAccount>();
        }
        #endregion

        public bool IsCorrectLoginInfo(StaffAccount loginAccount)
        {
            Table<DAL.StaffAccount> staffAccountTable = GetStaffAccountTable();

            var matchedRes = (from account in staffAccountTable
                              where account.username == loginAccount.Username && account.password == loginAccount.Password
                              select account).FirstOrDefault();

            return (matchedRes != null);
        }

        public string GetStaffID(string username)
        {
            Table<DAL.StaffAccount> staffAccountTable = GetStaffAccountTable();

            var matchedRes = (from account in staffAccountTable
                              where account.username == username
                              select account.staffID).FirstOrDefault();

            return matchedRes;
        }

        public string GetUsername(string staffID)
        {
            Table<DAL.StaffAccount> staffAccountTable = GetStaffAccountTable();

            var matchedRes = (from account in staffAccountTable
                              where account.staffID == staffID
                              select account.username).FirstOrDefault();

            return matchedRes;
        }

        internal string AddOrUpdateAccount(string staffID, string username, string password)
        {
            Table<DAL.StaffAccount> accTable = GetStaffAccountTable();

            var matchedRes = (from acc in accTable
                              where acc.staffID == staffID
                              select acc).FirstOrDefault();

            if (matchedRes == null)
            {
                StaffAccount temp = new StaffAccount(username, password);
                DAL.StaffAccount newData = new DAL.StaffAccount();

                try
                {
                    newData.staffID = staffID;
                    newData.username = temp.Username;
                    newData.password = temp.Password;

                    accTable.InsertOnSubmit(newData);
                    accTable.Context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            else if (matchedRes != null)
            {
                if (password != "")
                {
                    // Get encrypted password
                    StaffAccount temp = new StaffAccount(username, password);
                    password = temp.Password;
                }
                try
                {
                    matchedRes.username = username;
                    if (password != "")
                        matchedRes.password = password;

                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "";
        }
    }
}
