using System;
using Repository;

using System;

namespace HRIS.Data
{
    public partial class mf_EmployeeWorkDay : EntityBase
    {
        public int employeeId { get; set; }
        public int workDayId { get; set; }
        public int updatedBy { get; set; }
        public DateTime updatedDate { get; set; }

        public virtual mf_Employee mf_Employee { get; set; }
        public virtual mf_WorkDay mf_WorkDay { get; set; }
        public virtual sys_User sys_User { get; set; }

        public mf_EmployeeWorkDay()
        {
            updatedDate = System.DateTime.Now;
            deleted = false;
            InitializePartial();
        }

        partial void InitializePartial();
    }
}