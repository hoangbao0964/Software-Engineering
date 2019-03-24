using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BookCoffeeManagement.Entities.Schedule
{
    class DailySchedule
    {
        #region Attributes
        protected DateTime date;
        protected Dictionary<int, WorkingShift> workingShift;

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        protected Dictionary<int, WorkingShift> Shift
        {
            get
            {
                return workingShift;
            }

            set
            {
                workingShift = value;
            }
        }
        #endregion

        #region Constructors
        public DailySchedule()
        {
            Date = DateTime.Now;
            Shift = new Dictionary<int, WorkingShift>();
        }

        public DailySchedule(DateTime date)
        {
            Date = date;
            Shift = new Dictionary<int, WorkingShift>();
        }

        public DailySchedule(DateTime date, Dictionary<int, WorkingShift> shifts)
        {
            Date = date;
            Shift = shifts;
        }
        #endregion

        #region Methods
        public WorkingShift GetWorkingShift(int shiftNum)
        {
            if (Shift.ContainsKey(shiftNum))
                return Shift[shiftNum];
            return null;
        }

        public bool AddWorkingShift(WorkingShift shift)
        {
            Shift.Add(shift.ShiftID, shift);
            return true;
        }
        #endregion

    }
}
