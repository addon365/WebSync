using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Addon365.Models
{
    public class License:BaseModel
    {
       
        public string LicenseId { get; set; }
       
        public Product Product { get; set; }
        public Customer Customer { get; set; }
        public DateTime ActivatedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime InActiveDate { get; set; }

    }
}
