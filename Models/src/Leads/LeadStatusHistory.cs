using System;
using System.Collections.Generic;
using System.Text;

namespace Addon365.Models.Leads
{
    public class LeadStatusHistory : BaseModel
    {
        public Lead Lead { get; set; }
        public LeadStatusHistoryMaster Status { get; set; }
        public DateTime StatusDate { get; set; }
        public User User { get; set; }
    }
}
