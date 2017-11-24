using System;
using Repository;

using System;

namespace HRIS.Data
{
    public partial class mf_EmployeeTraining : EntityBase
    {
        public int employeeId { get; set; }
        public DateTime trainingDate { get; set; }
        public string trainingName { get; set; }
        public string description { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public int updatedBy { get; set; }
        public DateTime updatedDate { get; set; }

        public virtual mf_Employee mf_Employee { get; set; }
        public virtual sys_User sys_User { get; set; }

        public mf_EmployeeTraining()
        {
            updatedDate = System.DateTime.Now;
            deleted = false;
            InitializePartial();
        }

        partial void InitializePartial();
    }
}