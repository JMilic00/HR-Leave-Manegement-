using HR.LeaveManegement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManegement.Domain
{
    public class LeaveType : BaseDomainEntity
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}