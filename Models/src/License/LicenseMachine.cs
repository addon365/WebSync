using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Addon365.Models
{
    public class LicenseMachine:BaseModel
    {
        
        public string LicenseMachineId { get; set; }
        public string DeviceId { get; set; }

        [Required]
        public Guid LicenseId { get; set; }

        [ForeignKey("Id")]
        public virtual License License { get; set; }
        
    }
}
