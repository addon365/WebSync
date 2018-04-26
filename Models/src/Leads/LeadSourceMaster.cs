using System;
using System.Collections.Generic;
using System.Text;

namespace Addon365.Models.Leads
{
    public class LeadSource
    {
        public Guid LeadSourceId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public string ProgId { get; set; }


        public static LeadSource[] GetMasterData()
        {
            return new LeadSource[]
             {
                 new LeadSource
                {
                    LeadSourceId = Guid.NewGuid(),
                    Code = "JD",
                    Name = "Just Dial"
                },
                   new LeadSource
                {
                    LeadSourceId = Guid.NewGuid(),
                    Code = "QR",
                    Name = "Quickr"
                },
                     new LeadSource
                {
                    LeadSourceId = Guid.NewGuid(),
                    Code = "MT",
                    Name = "Marketter"
                },
                       new LeadSource
                {
                    LeadSourceId = Guid.NewGuid(),
                    Code = "FB",
                    Name = "Facebook"
                },
                         new LeadSource
                {
                    LeadSourceId = Guid.NewGuid(),
                    Code = "O",
                    Name = "Other"
                }
             };
        }
    }
}
