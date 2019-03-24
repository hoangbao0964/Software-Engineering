using Project_BookCoffeeManagement.Entities.People.Staffs;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BookCoffeeManagement.BLL
{
    class ParameterManager : Manager
    {
        private static Staff staffInfo = null;

        public static int GetVIPMembershipIncreasementDaysNumber()
        {
            Table<DAL.Parameter> paramTable = db.GetTable<DAL.Parameter>();

            var res = (from param in paramTable
                       where param.parameterName == "VIPMembershipIncreasement"
                       select param.value).FirstOrDefault();

            return int.Parse(res);
        }

        public static int GetShiftHour()
        {
            Table<DAL.Parameter> paramTable = db.GetTable<DAL.Parameter>();

            var res = (from param in paramTable
                       where param.parameterName == "shiftHour"
                       select param.value).FirstOrDefault();

            return int.Parse(res);
        }

        public static void SetStaffInfo(Staff staff)
        {
            staffInfo = staff;
        }

        public static Staff GetCurrentStaff()
        {
            return staffInfo;
        }

        public static int GetBookBorrowFeePercentage()
        {
            Table<DAL.Parameter> paramTable = db.GetTable<DAL.Parameter>();

            var res = (from param in paramTable
                       where param.parameterName == "bookBorrowFee"
                       select param.value).FirstOrDefault();

            return int.Parse(res);
        }

        public static int GetMaxBookBorrowDays()
        {
            Table<DAL.Parameter> paramTable = db.GetTable<DAL.Parameter>();

            var res = (from param in paramTable
                       where param.parameterName == "maxBookBorrowDay"
                       select param.value).FirstOrDefault();

            return int.Parse(res);
        }

        public static int GetVIPDiscount()
        {
            Table<DAL.Parameter> paramTable = db.GetTable<DAL.Parameter>();

            var res = (from param in paramTable
                       where param.parameterName == "vipDiscount"
                       select param.value).FirstOrDefault();

            return int.Parse(res);
        }

        public static double getLateFee(int type)
        {
            Table<DAL.Parameter> paramTable = db.GetTable<DAL.Parameter>();

            var res = (from param in paramTable
                       where param.parameterName == "latefee_" + type.ToString()
                       select param.value).FirstOrDefault();

            return int.Parse(res);
        }

        public static double getLateFeeRange(int type)
        {
            Table<DAL.Parameter> paramTable = db.GetTable<DAL.Parameter>();

            var res = (from param in paramTable
                       where param.parameterName == "latefee_range_" + type.ToString()
                       select param.value).FirstOrDefault();

            return int.Parse(res);
        }

    }
}
