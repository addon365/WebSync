using System;
using System.Collections.Generic;
using System.Text;

namespace Addon365.Models.Leads
{
    public class LeadStatus
    {
        public Guid LeadStatusId { get; set; }
        public string Name { get; set; }

        public static LeadStatus[] GetMasterData()
        {
            return new LeadStatus[]
           {
                new LeadStatus()
                {
                    LeadStatusId=Guid.NewGuid(),
                    Name="Open"
                },
                 new LeadStatus()
                {
                    LeadStatusId=Guid.NewGuid(),
                    Name="Followup"
                },
                  new LeadStatus()
                {
                    LeadStatusId=Guid.NewGuid(),
                    Name="Closed"
                },
                   new LeadStatus()
                {
                    LeadStatusId=Guid.NewGuid(),
                    Name="Demo"
                },
                    new LeadStatus()
                {
                    LeadStatusId=Guid.NewGuid(),
                    Name="Reschedule"
                },
                        new LeadStatus()
                {
                    LeadStatusId=Guid.NewGuid(),
                    Name="Advance"
                },
                new LeadStatus()
                {
                    LeadStatusId=Guid.NewGuid(),
                    Name="Installation"
                },
           };
        }
    }
}
