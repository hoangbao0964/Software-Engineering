using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BookCoffeeManagement.BLL.People
{
    public class PersonManager : Manager
    {
        #region Get Table
        public Table<DAL.Occupation> GetOccupationTable()
        {
            return db.GetTable<DAL.Occupation>();
        }

        public Table<DAL.Gender> GetGenderTable()
        {
            return db.GetTable<DAL.Gender>();
        }

        public Table<DAL.PersonalDetail> GetPersonalDetailTable()
        {
            return db.GetTable<DAL.PersonalDetail>();
        }
        #endregion

        #region Get Data
        public List<string> GetGenderList()
        {
            Table<DAL.Gender> genderTable = GetGenderTable();

            var res = (from gender in genderTable
                       select gender.name);

            return res.ToList();
        }

        public int GetGenderCode(string genderName)
        {
            Table<DAL.Gender> genderTable = GetGenderTable();

            var res = (from gender in genderTable
                       where gender.name == genderName
                       select gender.genderCode).FirstOrDefault();

            if (res == default(int))
            {
                string err = AddNewGender(genderName);
                return GetGenderCode(genderName);
            }

            return res;
        }

        public List<string> GetOccupationList()
        {
            Table<DAL.Occupation> occupationTable = GetOccupationTable();

            var res = (from occupation in occupationTable
                       select occupation.name);
            return res.ToList();
        }

        public int GetOccupationCode(string occupationName)
        {
            Table<DAL.Occupation> occupationTable = GetOccupationTable();

            var res = (from occupation in occupationTable
                       where occupation.name == occupationName
                       select occupation.occupationCode).FirstOrDefault();

            if (res == default(int))
            {
                string err = AddNewOccupation(occupationName);
                return GetOccupationCode(occupationName);
            }

            return res;
        }

        public int GetPersonalDetailsID(string civilianID)
        {
            Table<DAL.PersonalDetail> personTable = GetPersonalDetailTable();

            var matchedPerson = (from person in personTable
                                 where person.cilivianID == civilianID
                                 select person.personalDetailsID).FirstOrDefault();

            return matchedPerson;
        }

        #endregion

        #region Update Data
        protected string AddOrUpdatePersonDetails(string fullName, DateTime? dateOfBirth, string gender, string contactNumber, string civilianID, string address)
        {
            Table<DAL.PersonalDetail> personTable = GetPersonalDetailTable();

            var matchedPerson = (from person in personTable
                                 where person.cilivianID == civilianID
                                 select person).FirstOrDefault();

            if (matchedPerson == null)  // Add
            {
                DAL.PersonalDetail newData = new DAL.PersonalDetail();
                try
                {
                    newData.fullName = fullName;
                    newData.genderCode = GetGenderCode(gender);
                    newData.dateOfBirth = dateOfBirth;
                    newData.contactNumber = contactNumber;
                    newData.cilivianID = civilianID;
                    newData.address = address;

                    personTable.InsertOnSubmit(newData);
                    personTable.Context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            else
            {
                try
                {
                    matchedPerson.fullName = fullName;
                    matchedPerson.genderCode = GetGenderCode(gender);
                    matchedPerson.dateOfBirth = dateOfBirth;
                    matchedPerson.contactNumber = contactNumber;
                    matchedPerson.cilivianID = civilianID;
                    matchedPerson.address = address;

                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "";
        }

        protected string AddNewGender(string genderName)
        {
            Table<DAL.Gender> genderTable = GetGenderTable();
            DAL.Gender newGender = new DAL.Gender();
            try
            {
                newGender.name = genderName;
                genderTable.InsertOnSubmit(newGender);
                genderTable.Context.SubmitChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
        }

        protected string AddNewOccupation(string occupationName)
        {
            Table<DAL.Occupation> occupationTable = GetOccupationTable();
            DAL.Occupation newOccupation = new DAL.Occupation();

            try
            {
                newOccupation.name = occupationName;
                occupationTable.InsertOnSubmit(newOccupation);
                occupationTable.Context.SubmitChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
        }
        #endregion


    }
}
