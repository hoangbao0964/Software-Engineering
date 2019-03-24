using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_BookCoffeeManagement.Entities.People.Customers;

namespace Project_BookCoffeeManagement.BLL.People.Customers
{
    class VIPManager : PersonManager
    {
        #region Get Table
        public Table<DAL.VIP> GetVipTable()
        {
            return db.GetTable<DAL.VIP>();
        }

        public Table<DAL.PersonalDetail> GetPersonalDetailsTable()
        {
            return db.GetTable<DAL.PersonalDetail>();
        }

        public Table<DAL.VIPStatus> GetVipStatusTable()
        {
            return db.GetTable<DAL.VIPStatus>();
        }

        #endregion

        #region Get Data
        public List<VIP> GetVIPs()
        {
            Table<DAL.VIP> vipTable = GetVipTable();
            Table<DAL.PersonalDetail> personalDetailTable = GetPersonalDetailsTable();
            Table<DAL.VIPStatus> vipStatusTable = GetVipStatusTable();
            Table<DAL.Occupation> occupationTable = GetOccupationTable();
            Table<DAL.Gender> genderTable = GetGenderTable();
            var res = from vip in vipTable
                      join psDetails in personalDetailTable on vip.personalDetailsID equals psDetails.personalDetailsID
                      join vipStatus in vipStatusTable on vip.vipStatusCode equals vipStatus.vipStatusCode
                      join occu in occupationTable on vip.occupationCode equals occu.occupationCode
                      join gender in genderTable on psDetails.genderCode equals gender.genderCode
                      orderby vip.vipID ascending
                      select new VIP
                      {
                          VipID = vip.vipID,
                          FullName = psDetails.fullName,
                          Occupation = occu.name,
                          Gender = gender.name,
                          Address = psDetails.address,
                          CivilianID = psDetails.cilivianID,
                          ContactNumber = psDetails.contactNumber,
                          DateOfBirth = psDetails.dateOfBirth,
                          RegisterDate = vip.registerDate,
                          EndDate = vip.endDate,
                          VipStatus = vipStatus.name,
                      };

            foreach (VIP vip in res.ToList())
            {
                if (vip.EndDate < DateTime.Now)
                    UpdateVipStatus(vip.VipID, 2);
            }

            return res.ToList();
        }
       
        public List<object> SearchVip(string searchPharse1, string type1, string searchPharse2, string type2, string searchPharse3, string type3, string searchConstraint1, string searchConstraint2)
        {
            throw new NotImplementedException();
        }

        internal List<VIP> SearchVip(string keyword)
        {
            List<VIP> res = GetVIPs();
            keyword = keyword.ToLower();
            return res.Where(s => s.FullName.ToLower().Contains(keyword) || s.VipID.ToLower().Contains(keyword) || s.CivilianID.ToString().ToLower().Contains(keyword)).ToList();
        }

        public bool IsVIP(string vipID)
        {
            Table<DAL.VIP> vipTable = GetVipTable();

            var res = (from vip in vipTable
                       where vip.vipID == vipID
                       select vip).FirstOrDefault();

            return (res != null);
        }
        
        #endregion

        #region Update Data
        public string AddOrUpdateAVIP(VIP newVIP)
        {
            string err = AddOrUpdatePersonDetails(newVIP.FullName, newVIP.DateOfBirth, newVIP.Gender, newVIP.ContactNumber, newVIP.CivilianID, newVIP.Address);
            if (err != "")
                return err;

            int personalDetailsID = GetPersonalDetailsID(newVIP.CivilianID);
            Table<DAL.VIP> vipTable = GetVipTable();
            var matchedVIP = (from vip in vipTable
                              where vip.personalDetailsID == personalDetailsID
                              select vip).FirstOrDefault();

            if (matchedVIP == null)
            {
                DAL.VIP newData = new DAL.VIP();
                try
                {
                    newData.vipID = newVIP.VipID;
                    newData.personalDetailsID = personalDetailsID;
                    newData.occupationCode = GetOccupationCode(newVIP.Occupation);
                    newData.registerDate = DateTime.Now.Date;
                    newData.endDate = DateTime.Now.AddDays(ParameterManager.GetVIPMembershipIncreasementDaysNumber()).Date;
                    newData.vipStatusCode = 1;

                    vipTable.InsertOnSubmit(newData);
                    vipTable.Context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            else if (matchedVIP != null)
            {
                try
                {
                    matchedVIP.personalDetailsID = personalDetailsID;
                    matchedVIP.occupationCode = GetOccupationCode(newVIP.Occupation);

                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }

            return "";
        }

        internal string IncreaseVipMembership(string vipID)
        {
            Table<DAL.VIP> vipTable = GetVipTable();

            var res = (from vip in vipTable
                       where vip.vipID == vipID
                       select vip).FirstOrDefault();

            if (res != null)
            {
                try
                {
                    res.endDate = res.endDate.Value.Date.AddDays(ParameterManager.GetVIPMembershipIncreasementDaysNumber());
                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "";
        }
        private void UpdateVipStatus(string vipID, int statusCode)
        {
            Table<DAL.VIP> vipTable = GetVipTable();

            var res = (from vip in vipTable
                       where vip.vipID == vipID
                       select vip).FirstOrDefault();

            if (res != null)
            {
                res.vipStatusCode = statusCode;
                db.SubmitChanges();
            }
        }
        #endregion
    }
}
