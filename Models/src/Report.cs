using System;
using System.Collections.Generic;
using System.Text;

namespace Addon365.Models
{
    public class Report
    {

        public Guid ReportId { get; set; }

        public string CustomId { get; set; }

        public DateTime Date { get; set; }

        public decimal TotalAmount { get; set; }

        public License License { get; set; }

    }
}
