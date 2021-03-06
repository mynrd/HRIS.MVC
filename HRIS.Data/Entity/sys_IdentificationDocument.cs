using Repository;
using System;
using System.Collections.Generic;

namespace HRIS.Data.Entity
{
    public class sys_IdentificationDocument : EntityBase
    {
        public string code { get; set; }
        public string description { get; set; }
        public Guid updatedBy { get; set; }
        public DateTime updatedDate { get; set; }

        public virtual ICollection<mf_EmployeeIdentificationDocument> mf_EmployeeIdentificationDocuments { get; set; }

        public virtual sys_User sys_User_updatedBy { get; set; }

        public sys_IdentificationDocument()
        {
            updatedDate = System.DateTime.Now;
            deleted = false;
            mf_EmployeeIdentificationDocuments = new List<mf_EmployeeIdentificationDocument>();
        }
    }
}