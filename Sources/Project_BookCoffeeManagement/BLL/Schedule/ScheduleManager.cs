using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_BookCoffeeManagement.Entities.Schedule;
using System.Data.Linq;
using Project_BookCoffeeManagement.BLL.People.Staffs;
using Project_BookCoffeeManagement.Entities.People.Staffs;

namespace Project_BookCoffeeManagement.BLL.Schedule
{
    class ScheduleManager : Manager
    {
        private StaffManager staffManager;

        public ScheduleManager()
        {
            staffManager = new StaffManager();
        }

        #region Get Table
        public Table<DAL.Schedule> GetScheduleTable()
        {
            return db.GetTable<DAL.Schedule>();
        }

        public Table<DAL.WorkingShiftInfo> GetWorkingShiftInfo()
        {
            return db.GetTable<DAL.WorkingShiftInfo>();
        }

        public Table<DAL.WorkingCashier> GetWorkingCashierTable()
        {
            return db.GetTable<DAL.WorkingCashier>();
        }

        public Table<DAL.WorkingManager> GetWorkingManagerTable()
        {
            return db.GetTable<DAL.WorkingManager>();
        }

        public Table<DAL.WorkingRegularStaff> GetWorkingRegularStaffTable()
        {
            return db.GetTable<DAL.WorkingRegularStaff>();
        }

        public Table<DAL.WorkingWarehouseManager> GetWorkingWarehouseManagerTable()
        {
            return db.GetTable<DAL.WorkingWarehouseManager>();
        }
        #endregion

        #region Get Data
        public DailySchedule GetSchedule(DateTime date)
        {
            DailySchedule schedule = new DailySchedule(date);
            Table<DAL.Schedule> scheduleTable = GetScheduleTable();
            Table<DAL.WorkingCashier> cashierTable = GetWorkingCashierTable();
            Table<DAL.WorkingManager> managerTable = GetWorkingManagerTable();
            Table<DAL.WorkingRegularStaff> staffTable = GetWorkingRegularStaffTable();
            Table<DAL.WorkingWarehouseManager> warehouseManagerTable = GetWorkingWarehouseManagerTable();

            var matchedScheduleInDate = (from sch in scheduleTable
                                         where date.Date.CompareTo(sch.date) == 0
                                         select sch).ToList();

            foreach (DAL.Schedule matchedData in matchedScheduleInDate)
            {
                WorkingShift newShift = new WorkingShift(matchedData.workingShiftID);
                var matchedCashier = (from cashier in cashierTable
                                      where matchedData.scheduleID == cashier.scheduleID
                                      select cashier.staffID).ToList();
                foreach (string cashierID in matchedCashier)
                    newShift.AddWorkingStaff(staffManager.GetStaff(cashierID));

                var matchedManager = (from manager in managerTable
                                      where matchedData.scheduleID == manager.scheduleID
                                      select manager.staffID).ToList();
                foreach (string managerID in matchedManager)
                    newShift.AddWorkingStaff(staffManager.GetStaff(managerID));

                var matchedStaff = (from staff in staffTable
                                      where matchedData.scheduleID == staff.scheduleID
                                      select staff.staffID).ToList();
                foreach (string staffID in matchedStaff)
                    newShift.AddWorkingStaff(staffManager.GetStaff(staffID));

                var matchedKeeper = (from keeper in warehouseManagerTable
                                      where matchedData.scheduleID == keeper.scheduleID
                                      select keeper.staffID).ToList();
                foreach (string keeperID in matchedKeeper)
                    newShift.AddWorkingStaff(staffManager.GetStaff(keeperID));

                schedule.AddWorkingShift(newShift);
            }

            return schedule;
        }
        #endregion

        #region Update Data
        public string AddOrUpdateSchedule(List<WorkingShift> newSchedule)
        {
            foreach (WorkingShift schedule in newSchedule)
            {
                string err = AddOrUpdateScheduleShift(schedule);
                if (err != "")
                    return err;
            }
            return "";
        }

        private string AddOrUpdateScheduleShift(WorkingShift schedule)
        {
            Table<DAL.Schedule> scheduleTable = GetScheduleTable();
            int matchedScheduleID = (from sch in scheduleTable
                                     where schedule.StartTime.Date.CompareTo(sch.date) == 0 && sch.workingShiftID == schedule.ShiftID
                                     select sch.scheduleID).FirstOrDefault();

            if (matchedScheduleID == default(int))
            {
                // Create new schedule
                DAL.Schedule newData = new DAL.Schedule();
                try
                {
                    newData.date = schedule.StartTime.Date;
                    newData.workingShiftID = schedule.ShiftID;

                    scheduleTable.InsertOnSubmit(newData);
                    scheduleTable.Context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

                matchedScheduleID = newData.scheduleID;
            }

            string err = DeleteCurrentWorkingStaffInfo(matchedScheduleID);
            if (err != "")
                return err;

            foreach (Staff staff in schedule.WorkingStaff.Values)
            {
                err = "No data updated";
                if (staffManager.GetPositionCode(staff.CurrentPosition) == 1)
                    err = AddOrNewWorkingCashier(staff, matchedScheduleID);
                else if (staffManager.GetPositionCode(staff.CurrentPosition) == 2)
                    err = AddOrUpdateNewWorkingManager(staff, matchedScheduleID);
                else if (staffManager.GetPositionCode(staff.CurrentPosition) == 3)
                    err = AddOrUpdateNewWorkingKeeper(staff, matchedScheduleID);
                else if (staffManager.GetPositionCode(staff.CurrentPosition) == 4)
                    err = AddOrUpdateNewWorkingStaff(staff, matchedScheduleID);
                if (err != "")
                    return err;
                staffManager.AddWorkingHours(staff.StaffID, ParameterManager.GetShiftHour());
            }

            return "";
        }

        private string DeleteCurrentWorkingStaffInfo(int matchedScheduleID)
        {
            Table<DAL.WorkingRegularStaff> staffTable = GetWorkingRegularStaffTable();
            Table<DAL.WorkingWarehouseManager> keeperTable = GetWorkingWarehouseManagerTable();
            Table<DAL.WorkingManager> managerTable = GetWorkingManagerTable();
            Table<DAL.WorkingCashier> cashierTable = GetWorkingCashierTable();
            List<string> deletedStaff = new List<string>();
            try
            {
                var matchedRes1 = (from st in staffTable
                                   where st.scheduleID == matchedScheduleID
                                   select st).ToList();
                foreach (DAL.WorkingRegularStaff staff in matchedRes1)
                {
                    staffTable.DeleteOnSubmit(staff);
                    deletedStaff.Add(staff.staffID);
                }

                var matchedRes2 = (from st in keeperTable
                                   where st.scheduleID == matchedScheduleID
                                   select st).ToList();
                foreach (DAL.WorkingWarehouseManager staff in matchedRes2)
                {
                    keeperTable.DeleteOnSubmit(staff);
                    deletedStaff.Add(staff.staffID);
                }

                var matchedRes3 = (from st in managerTable
                                   where st.scheduleID == matchedScheduleID
                                   select st).ToList();
                foreach (DAL.WorkingManager staff in matchedRes3)
                {
                    managerTable.DeleteOnSubmit(staff);
                    deletedStaff.Add(staff.staffID);
                }

                var matchedRes4 = (from st in cashierTable
                                   where st.scheduleID == matchedScheduleID
                                   select st).ToList();
                foreach (DAL.WorkingCashier staff in matchedRes4)
                {
                    cashierTable.DeleteOnSubmit(staff);
                    deletedStaff.Add(staff.staffID);
                }

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            foreach (string id in deletedStaff)
            {
                string err = staffManager.SubtractWorkingHours(id, ParameterManager.GetShiftHour());
                if (err != "")
                    return err;
            }
            
            return "";
        }

        private string AddOrUpdateNewWorkingStaff(Staff staff, int matchedScheduleID)
        {
            Table<DAL.WorkingRegularStaff> staffTable = GetWorkingRegularStaffTable();

            DAL.WorkingRegularStaff data = new DAL.WorkingRegularStaff();
            try
            {
                data.scheduleID = matchedScheduleID;
                data.staffID = staff.StaffID;

                staffTable.InsertOnSubmit(data);
                staffTable.Context.SubmitChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
        }

        private string AddOrUpdateNewWorkingKeeper(Staff staff, int matchedScheduleID)
        {
            Table<DAL.WorkingWarehouseManager> staffTable = GetWorkingWarehouseManagerTable();

            DAL.WorkingWarehouseManager data = new DAL.WorkingWarehouseManager();
            try
            {
                data.scheduleID = matchedScheduleID;
                data.staffID = staff.StaffID;

                staffTable.InsertOnSubmit(data);
                staffTable.Context.SubmitChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
        }

        private string AddOrUpdateNewWorkingManager(Staff staff, int matchedScheduleID)
        {
            Table<DAL.WorkingManager> staffTable = GetWorkingManagerTable();

            DAL.WorkingManager data = new DAL.WorkingManager();
            try
            {
                data.scheduleID = matchedScheduleID;
                data.staffID = staff.StaffID;

                staffTable.InsertOnSubmit(data);
                staffTable.Context.SubmitChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
        }

        private string AddOrNewWorkingCashier(Staff staff, int matchedScheduleID)
        {
            Table<DAL.WorkingCashier> staffTable = GetWorkingCashierTable();

            DAL.WorkingCashier data = new DAL.WorkingCashier();
            try
            {
                data.scheduleID = matchedScheduleID;
                data.staffID = staff.StaffID;

                staffTable.InsertOnSubmit(data);
                staffTable.Context.SubmitChanges();
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
