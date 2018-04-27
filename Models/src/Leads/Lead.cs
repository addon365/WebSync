using System;
using System.Collections.Generic;
using System.Text;

namespace Addon365.Models.Leads
{
    public class Lead
    {
        public Guid LeadId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid LeadSourceId { get; set; }
        public Guid ProfileId { get; set; }
        public Guid UserId { get; set; }
        public string Comments { get; set; }

        public LeadSource LeadSource { get; set; }
        public Profile Profile { get; set; }
    }
}
