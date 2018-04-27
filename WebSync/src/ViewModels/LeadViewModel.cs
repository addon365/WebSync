using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Addon365.WebSync.ViewModels
{
    public class LeadViewModel
    {
        public Guid LeadId { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }
        public string MobileNumber { get; set; }
        public Guid SourceId { get; set; }
        public string CreatedDate { get; set; }
    }
}
