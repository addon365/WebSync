using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Addon365.WebSync.ViewModels
{
    public class LeadViewModel
    {
        public Guid LeadViewModelId { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public Guid SourceId { get; set; }
        public string CreatedDate { get; set; }
    }
}
