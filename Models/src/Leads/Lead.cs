using System;
using System.Collections.Generic;
using System.Text;

namespace Addon365.Models.Leads
{
    public class Lead : BaseModel
    {

        public Profile Profile { get; set; }
        public LeadSourceMaster Source { get; set; }


    }
}
