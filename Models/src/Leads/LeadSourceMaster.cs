using System;
using System.Collections.Generic;
using System.Text;

namespace Addon365.Models.Leads
{
    public class LeadSourceMaster :BaseModel
    {
        
        public string Name { get; set; }
        public string Code { get; set; }

        public string ProgId { get; set; }
    }
}
