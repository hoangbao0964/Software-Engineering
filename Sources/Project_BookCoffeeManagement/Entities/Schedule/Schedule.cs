using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BookCoffeeManagement.Entities.Schedule
{
    class Schedule
    {
        #region Attribute
        protected Dictionary<DateTime, DailySchedule> schedules;
        #endregion

        #region Constructors
        public Schedule()
        {
            schedules = new Dictionary<DateTime, DailySchedule>();
        }

        public Schedule(Dictionary<DateTime, DailySchedule> schedules)
        {
            this.schedules = schedules;
        }
        #endregion

        #region Get - Set methods
        public DailySchedule GetSchedule(DateTime date)
        {
            if (schedules.ContainsKey(date))
                return schedules[date];
            return null;
        }

        public bool AddSchedule(DailySchedule schedule)
        {
            schedules.Add(schedule.Date, schedule);
            return true;
        }

        public Dictionary<DateTime, DailySchedule> GetSchedule()
        {
            return schedules;
        }
        #endregion
    }
}
