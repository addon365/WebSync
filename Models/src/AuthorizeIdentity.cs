using System;
using System.Collections.Generic;
using System.Text;

namespace Addon365.Models
{
    class AuthorizeIdentity
    {
        public Guid AuthorizeIdentityId { get; set; }

        public License License { get; set; }

        public string Provider { get; set; }

        public string Identity { get; set; }
    }
}
