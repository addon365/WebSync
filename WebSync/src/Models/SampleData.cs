using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Addon365.Models;

namespace Addon365.WebSync.Models
{
    public static class SampleData
    {
        public static License[] lic;
        public static Profile[] pro;
        public static Customer[] cus;
        public static LicenseMachine[] licMac;

        private static void PopulateProfile()
        {
            pro = new Profile[1];
            pro[0] = new Profile { Id = Guid.NewGuid(), Name = "Tamilselvan" };
        }
        private static void PopulateCustomer()
        {
            PopulateProfile();
            cus = new Customer[1];
           cus[0] = new Customer { Id = Guid.NewGuid(), Profile = pro[0]};
        }
        private static void PopulateLicense()
        {
            PopulateCustomer();
            lic = new License[1];
            lic[0] = new License { Id = Guid.NewGuid(), Customer = cus[0] };
        }
        public static void PopulateLicenseMachine()
        {
            PopulateLicense();
            licMac = new LicenseMachine[1];
            licMac[0] = new LicenseMachine { DeviceId = "12313424", License = lic[0] };
        }
    }
}
