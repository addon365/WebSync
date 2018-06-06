using System;
using System.Collections.Generic;
using System.Text;
#if EF
using System.ComponentModel.DataAnnotations;
#endif
namespace Addon365.Models
{
    public class BaseModel
    {
#if EF
        [Key]
#endif
        public Guid Id { get; set; }
    }
}
