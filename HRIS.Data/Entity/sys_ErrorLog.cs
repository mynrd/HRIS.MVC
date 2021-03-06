using Repository;
using System;

namespace HRIS.Data.Entity
{
    public class sys_ErrorLog : EntityBase
    {
        public string message { get; set; }
        public string innerException { get; set; }
        public int loggedType { get; set; }
        public string controllerName { get; set; }
        public string actionName { get; set; }
        public string areaName { get; set; }
        public Guid? createdBy { get; set; }
        public DateTime createdDate { get; set; }

        public virtual sys_User sys_User { get; set; }

        public sys_ErrorLog()
        {
            createdDate = System.DateTime.Now;
        }
    }
}