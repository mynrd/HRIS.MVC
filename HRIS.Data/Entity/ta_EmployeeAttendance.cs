using Repository;
using System;

namespace HRIS.Data.Entity
{
    public class ta_EmployeeAttendance : EntityBase
    {
        public Guid employeeId { get; set; }
        public int timeLogType { get; set; }
        public DateTime workDate { get; set; }
        public DateTime timeLog { get; set; }
        public Guid? workDayId { get; set; }
        public string remarks { get; set; }
        public Guid updatedBy { get; set; }
        public DateTime updatedDate { get; set; }

        public virtual mf_Employee mf_Employee { get; set; }
        public virtual mf_WorkDay mf_WorkDay { get; set; }
        public virtual sys_User sys_User_updatedBy { get; set; }

        public ta_EmployeeAttendance()
        {
            updatedDate = System.DateTime.Now;
            deleted = false;
        }
    }
}