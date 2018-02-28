using System;

namespace Addon365.Models
{
    public class Identifier
    {
        public Guid IdentifierId { get; set;}

        public string CustomId { get; set; }
        public string Name { get; set; }
        public string AuthorizedGMail { get; set; }
        public string MobileNumer { get; set; }
    }
}
