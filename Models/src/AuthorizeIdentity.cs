using System;
using System.Collections.Generic;
using System.Text;

namespace Addon365.Models
{
    class AuthorizeIdentity : BaseModel
    {


        public User User { get; set; }

        public string Provider { get; set; }

        public string Identity { get; set; }

        public DateTime AuthorizeDate { get; set; }
    }
}

