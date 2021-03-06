using Repository;
using System;
using System.Collections.Generic;

namespace HRIS.Data.Entity
{
    public class mf_Country : EntityBase
    {
        public string code { get; set; }
        public string description { get; set; }
        public Guid? updatedBy { get; set; }
        public DateTime updatedDate { get; set; }

        public virtual ICollection<mf_EmployeeAddress> mf_EmployeeAddresses { get; set; }
        public virtual ICollection<sys_Company> sys_Companies { get; set; }

        public virtual sys_User sys_User_updatedBy { get; set; }

        public mf_Country()
        {
            updatedDate = System.DateTime.Now;
            deleted = false;
            mf_EmployeeAddresses = new List<mf_EmployeeAddress>();
            sys_Companies = new List<sys_Company>();
        }
    }
}