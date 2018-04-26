using System;
using System.Collections.Generic;
using System.Text;

namespace Addon365.Models.Leads
{
    public class LeadStatusHistoryMaster
    {
        public Guid LeadStatusHistoryId { get; set; }
        public string Name { get; set; }

        public static LeadStatusHistoryMaster[] GetMasterData()
        {
            return new LeadStatusHistoryMaster[]
           {
                new LeadStatusHistoryMaster()
                {
                    LeadStatusHistoryId=Guid.NewGuid(),
                    Name="Open"
                },
                 new LeadStatusHistoryMaster()
                {
                    LeadStatusHistoryId=Guid.NewGuid(),
                    Name="Followup"
                },
                  new LeadStatusHistoryMaster()
                {
                    LeadStatusHistoryId=Guid.NewGuid(),
                    Name="Closed"
                },
                   new LeadStatusHistoryMaster()
                {
                    LeadStatusHistoryId=Guid.NewGuid(),
                    Name="Demo"
                },
                    new LeadStatusHistoryMaster()
                {
                    LeadStatusHistoryId=Guid.NewGuid(),
                    Name="Reschedule"
                },
                        new LeadStatusHistoryMaster()
                {
                    LeadStatusHistoryId=Guid.NewGuid(),
                    Name="Advance"
                },
                new LeadStatusHistoryMaster()
                {
                    LeadStatusHistoryId=Guid.NewGuid(),
                    Name="Installation"
                },
           };
        }
    }
}
