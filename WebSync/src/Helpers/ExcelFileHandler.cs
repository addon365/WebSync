using Addon365.Models;
using Addon365.Models.Leads;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Addon365.WebSync.Helpers
{
    public static class ExcelFileHandler
    {

        public static IList<Lead> LoadExcelData(string fileName, List<LeadSource> sources)
        {
            IList<Lead> leads = null;

            using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    leads = new List<Lead>(reader.RowCount);
                    //Skipping the First row.
                    reader.Read();

                    while (reader.Read())
                    {
                        Lead lead = new Lead();
                        Profile profile = new Profile();
                        lead.UserId = new Guid("c8a790ae-90b7-4dda-ad1d-fdd97a804b0c");
                        profile.Name = reader.GetString(1);
                        profile.Address1 = reader.GetString(2);
                        profile.Address2 = reader.GetString(3);
                        profile.Area = reader.GetString(4);
                        profile.City = reader.GetString(5);
                        profile.District = reader.GetString(6);
                        profile.State = reader.GetString(7);
                        if (!reader.IsDBNull(8))
                            profile.Pincode = reader.GetDouble(8).ToString();
                        if (reader.IsDBNull(9))
                            return null;
                        profile.MobileNumber = reader.GetDouble(9).ToString();

                        lead.LeadSourceId = sources
                        .Where(s => s.Name.CompareTo(reader.GetString(10)) == 0)
                        .FirstOrDefault()
                        .LeadSourceId;
                        lead.CreatedDate = DateTime.Now;
                        lead.Comments = reader.GetString(11);
                        lead.Profile = profile;
                        leads.Add(lead);
                    }

                }
            }
            return leads;
        }
    }
}
