using System;
using System.Collections.Generic;
using System.Text;

namespace Addon365.Models.Leads
{
    public class LeadStatusHistory
    {
        public Guid LeadStatusHistoryId { get; set; }
        public Guid LeadId { get; set; }
        public Guid LeadStatusId { get; set; }
        public Guid UserId { get; set; }
        public DateTime StatusDate { get; set; }
        public string Comments { get; set; }

        public Lead Lead { get; set; }
        public User AssignedTo { get; set; }
        public LeadStatus Status { get; set; }
    }
}
