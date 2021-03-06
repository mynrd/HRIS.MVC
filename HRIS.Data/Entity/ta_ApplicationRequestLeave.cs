using Repository;
using System;

namespace HRIS.Data.Entity
{
    public class ta_ApplicationRequestLeave : EntityBase
    {
        public Guid applicationRequestId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        public virtual ta_ApplicationRequest ta_ApplicationRequest { get; set; }

        public ta_ApplicationRequestLeave()
        {
            deleted = false;
        }
    }
}