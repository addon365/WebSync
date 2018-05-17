using System;

namespace Addon365.Models
{
    public class Customer:BaseModel
    {

        public string CustomerId { get; set; }
        public Profile Profile { get; set; }
        
    }
}
