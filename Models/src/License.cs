using System;
using System.Collections.Generic;
using System.Text;

namespace Addon365.Models
{
    public class License
    {
        public Guid LicenseId { get; set; }
        public string CustomId { get; set; }
        public Product Product { get; set; }
        public Identifier Identifier { get; set; }
        public DateTime ActivatedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime InActiveDate{ get; set; } 

    }
}
