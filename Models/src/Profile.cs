using System;

namespace Addon365.Models
{
    public class Profile
    {
        public Guid ProfileId { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }
        public string MobileNumber { get; set; }
    }
}
