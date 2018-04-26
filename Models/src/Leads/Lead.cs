using System;
using System.Collections.Generic;
using System.Text;

namespace Addon365.Models.Leads
{
    public class Lead
    {
        public Guid LeadId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid SourceId { get; set; }
        public string Comments { get; set; }
        public Profile Profile { get; set; }
        public User CreatedBy { get; set; }
        
    }
}
