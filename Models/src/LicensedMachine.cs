using System;
using System.Collections.Generic;
using System.Text;

namespace Addon365.Models
{
    public class LicensedMachine
    {
        public Guid LicensedMachineId { get; set; }
        public string CustomId { get; set; }
        public string DeviceId { get; set; }
        public License License { get; set; }
        
    }
}
