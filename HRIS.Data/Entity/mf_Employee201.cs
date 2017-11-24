using Repository;
using System;
using System.Collections.Generic;

namespace HRIS.Data.Entity
{
    public partial class mf_Employee201 : EntityBase
    {
        public string employeeCode { get; set; }
        public int? departmentId { get; set; }
        public int? departmentSectionId { get; set; }
        public int? positionId { get; set; }
        public string email { get; set; }
        public int? employmentTypeId { get; set; }
        public int? employmentStatusId { get; set; }
        public int? positionLevel { get; set; }
        public DateTime? dateHired { get; set; }
        public DateTime? resignedDate { get; set; }
        public int? taxStatus { get; set; }
        public bool? timeSheetRequired { get; set; }
        public bool? entitledUnworkRegularHoliday { get; set; }
        public bool? entitledUnworkSpecialHoliday { get; set; }
        public bool? entitledOvertime { get; set; }
        public bool? entitledHolidayPay { get; set; }
        public int? payrollGroupId { get; set; }
        public int? agencyId { get; set; }
        public int updatedBy { get; set; }
        public DateTime updatedDate { get; set; }
        public bool confidential { get; set; }

        public virtual ICollection<mf_Employee> mf_Employees { get; set; }

        public virtual mf_Agency mf_Agency { get; set; }
        public virtual mf_Department mf_Department { get; set; }
        public virtual mf_DepartmentSection mf_DepartmentSection { get; set; }
        public virtual mf_EmploymentStatu mf_EmploymentStatu { get; set; }
        public virtual mf_EmploymentType mf_EmploymentType { get; set; }
        public virtual mf_PayrollGroup mf_PayrollGroup { get; set; }
        public virtual mf_Position mf_Position { get; set; }
        public virtual sys_User sys_User { get; set; }

        public mf_Employee201()
        {
            timeSheetRequired = true;
            entitledUnworkRegularHoliday = true;
            entitledUnworkSpecialHoliday = true;
            updatedDate = System.DateTime.Now;
            deleted = false;
            confidential = false;
            mf_Employees = new List<mf_Employee>();
            InitializePartial();
        }

        partial void InitializePartial();
    }
}