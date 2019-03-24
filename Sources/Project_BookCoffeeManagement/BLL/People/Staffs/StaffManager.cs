using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_BookCoffeeManagement.Entities.People.Staffs;

namespace Project_BookCoffeeManagement.BLL.People.Staffs
{
    public class StaffManager : PersonManager
    {
        #region Get Table
        private Table<DAL.StaffDetail> GetStaffDetailTable()
        {
            return db.GetTable<DAL.StaffDetail>();
        }

        private Table<DAL.StaffStatus> GetStaffStatusTable()
        {
            return db.GetTable<DAL.StaffStatus>();
        }

        private Table<DAL.StaffPosition> GetStaffPositionTable()
        {
            return db.GetTable<DAL.StaffPosition>();
        }
        #endregion

        #region Get Data
        public List<Staff> GetStaffs()
        {
            Table<DAL.StaffDetail> staffDetailTable = this.GetStaffDetailTable();
            Table<DAL.PersonalDetail> personalDetailTable = GetPersonalDetailTable();
            Table<DAL.StaffStatus> staffStatusTable = this.GetStaffStatusTable();
            Table<DAL.StaffPosition> staffPositionTable = this.GetStaffPositionTable();
            Table<DAL.Gender> genderTable = GetGenderTable();
            Table<DAL.Occupation> occupationTable = this.GetOccupationTable();

            var res = from sf in staffDetailTable
                      join psDetails in personalDetailTable on sf.personalDetailsID equals psDetails.personalDetailsID
                      join sfStatus in staffStatusTable on sf.staffStatusCode equals sfStatus.staffStatusCode
                      join sfPosition in staffPositionTable on sf.positionCode equals sfPosition.positionCode
                      join gender in genderTable on psDetails.genderCode equals gender.genderCode
                      join occupation in occupationTable on sf.occupationCode equals occupation.occupationCode
                      orderby sf.staffID ascending

                      select new Staff
                      {
                          StaffID = sf.staffID,
                          FullName = psDetails.fullName,
                          Gender = gender.name,
                          Address = psDetails.address,
                          CivilianID = psDetails.cilivianID,
                          ContactNumber = psDetails.contactNumber,
                          DateOfBirth = psDetails.dateOfBirth,
                          CurrentPosition = sfPosition.name,
                          CurrentSalaryPerHour = sf.currentSalaryPerHour,
                          WorkingHours = sf.workingHour,
                          StaffStatus = sfStatus.name,
                          Occupation = occupation.name,
                          Description = sf.description
                      };
            return res.ToList();
        }

        internal List<Staff> Filter(string keyword, List<Staff> staffs)
        {
            keyword = keyword.ToLower();
            return staffs.Where(s => s.StaffID.ToLower().Contains(keyword) || s.FullName.ToLower().Contains(keyword)).ToList();
        }

        public Staff GetStaff(string staffID)
        {
            List<Staff> res = GetStaffs();
            return res.Where(s => s.StaffID == staffID).FirstOrDefault();
        }

        public List<object> SearchStaff(string searchPharse1, string type1, string searchPharse2, string type2, string searchPharse3, string type3, string searchConstraint1, string searchConstraint2)
        {
            throw new NotImplementedException();
        }

        internal List<Staff> SearchStaff(string keyword)
        {
            List<Staff> res = GetStaffs();
            return Filter(keyword, res);
        }

        public List<string> GetStaffStatusList()
        {
            Table<DAL.StaffStatus> statusTable = GetStaffStatusTable();

            var res = (from status in statusTable
                       select status.name);

            return res.ToList();
        }

        public List<string> GetStaffPositionList()
        {
            Table<DAL.StaffPosition> positionTable = GetStaffPositionTable();

            var res = (from position in positionTable
                       select position.name);

            return res.ToList();
        }

        public string GetStaffIDFromCivilianID(string civilianID)
        {
            Table<DAL.StaffDetail> staffDetailTable = this.GetStaffDetailTable();
            Table<DAL.PersonalDetail> personalDetailTable = GetPersonalDetailTable();

            var res = (from sf in staffDetailTable
                       join psDetails in personalDetailTable on sf.personalDetailsID equals psDetails.personalDetailsID
                       where psDetails.cilivianID == civilianID
                       select sf.staffID).FirstOrDefault();
            return res;
        }

        public int GetPositionCode(string currentPosition)
        {
            Table<DAL.StaffPosition> staffPositionTable = this.GetStaffPositionTable();

            var res = (from position in staffPositionTable
                       where position.name == currentPosition
                       select position.positionCode).FirstOrDefault();

            return res;
        }

        private int GetStaffStatusCode(string staffStatus)
        {
            Table<DAL.StaffStatus> statusTable = GetStaffStatusTable();

            var res = (from status in statusTable
                       where status.name == staffStatus
                       select status.staffStatusCode).FirstOrDefault();

            return res;
        }
        #endregion

        #region Update Data
        public string AddOrUpdateStaff(Staff newStaff)
        {
            Table<DAL.StaffDetail> staffTable = GetStaffDetailTable();
            string err = AddOrUpdatePersonDetails(newStaff.FullName, newStaff.DateOfBirth, newStaff.Gender,newStaff.ContactNumber, newStaff.CivilianID, newStaff.Address);
            if (err != "")
                return err;

            int personalDetailID = GetPersonalDetailsID(newStaff.CivilianID);

            var matchedRes = (from staff in staffTable
                              where staff.staffID == newStaff.StaffID
                              select staff).FirstOrDefault();

            if (matchedRes == null)
            {
                try
                {
                    DAL.StaffDetail newDetail = new DAL.StaffDetail();

                    Random rnd = new Random();
                    newDetail.staffID = rnd.Next().ToString();        // Dummy init
                    newDetail.personalDetailsID = personalDetailID;
                    newDetail.positionCode = GetPositionCode(newStaff.CurrentPosition);
                    newDetail.currentSalaryPerHour = newStaff.CurrentSalaryPerHour;
                    newDetail.description = newStaff.Description;
                    newDetail.workingHour = 0;
                    newDetail.staffStatusCode = 2;
                    newDetail.occupationCode = GetOccupationCode(newStaff.Occupation);
                    newDetail.staffStatusCode = GetStaffStatusCode(newStaff.StaffStatus);

                    staffTable.InsertOnSubmit(newDetail);
                    staffTable.Context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            if (matchedRes != null)
            {
                try
                {
                    matchedRes.personalDetailsID = personalDetailID;
                    matchedRes.positionCode = GetPositionCode(newStaff.CurrentPosition);
                    matchedRes.currentSalaryPerHour = newStaff.CurrentSalaryPerHour;
                    matchedRes.description = newStaff.Description;
                    matchedRes.staffStatusCode = GetStaffStatusCode(newStaff.StaffStatus);

                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "";
        }

        public string AddWorkingHours(string staffID, int workingHour)
        {
            Table<DAL.StaffDetail> staffTable = GetStaffDetailTable();
            var matchedRes = (from staff in staffTable
                              where staff.staffID == staffID
                              select staff).FirstOrDefault();

            if (matchedRes != null)
            {
                try
                {
                    matchedRes.workingHour += workingHour;
                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }   
            }

            return "";
        }

        public string SubtractWorkingHours(string staffID, int workingHour)
        {
            Table<DAL.StaffDetail> staffTable = GetStaffDetailTable();
            var matchedRes = (from staff in staffTable
                              where staff.staffID == staffID
                              select staff).FirstOrDefault();

            if (matchedRes != null)
            {
                try
                {
                    matchedRes.workingHour -= workingHour;
                    if (matchedRes.workingHour < 0)
                        matchedRes.workingHour = 0;
                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }

            return "";
        }   
        #endregion
    }
}
