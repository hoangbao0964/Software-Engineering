using Project_BookCoffeeManagement.Entities.People.Staffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BookCoffeeManagement.Entities.Schedule
{
    class WorkingShift
    {
        #region Attributes
        protected DateTime startTime;
        protected DateTime endTime;
        protected int shiftID;
        protected Dictionary<string, Staff> workingStaff;


        public DateTime StartTime
        {
            get
            {
                return startTime;
            }

            set
            {
                startTime = value;
            }
        }
        public DateTime EndTime
        {
            get
            {
                return endTime;
            }

            set
            {
                endTime = value;
            }
        }
        public int ShiftID
        {
            get
            {
                return shiftID;
            }

            set
            {
                shiftID = value;
            }
        }
        public Dictionary<string, Staff> WorkingStaff
        {
            get
            {
                return workingStaff;
            }

            set
            {
                workingStaff = value;
            }
        }
        #endregion

        #region Constructors
        public WorkingShift(int shiftnum)
        {
            StartTime = DateTime.Now;
            EndTime = DateTime.Now;
            ShiftID = shiftnum;
            InitList();
        }

        private void InitList()
        {
            WorkingStaff = new Dictionary<string, Staff>();
        }

        public WorkingShift(DateTime start, DateTime end, int shiftID)
        {
            StartTime = start;
            EndTime = end;
            ShiftID = shiftID;
            InitList();
        }
        #endregion

        #region Methods
        public bool AddWorkingStaff(Staff staffInfo)
        {
            workingStaff.Add(staffInfo.StaffID, staffInfo);
            return true;
        }
        #endregion
    }
}
