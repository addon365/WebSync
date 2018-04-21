﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Addon365.Models
{
    public class User
    {
        public Guid Id { get; set; }
        
        public Profile Profile { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        
    }
}
