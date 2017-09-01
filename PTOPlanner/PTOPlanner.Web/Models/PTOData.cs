using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTOPlanner.Web.Models
{
    public class PTOData
    {
        public int EmployeePTOBalanceID { get; set; }
        public int EmployeeID { get; set; }
        public string WeekEnding { get; set; }
        public decimal PTOBalance { get; set; }
        public decimal RequestedHours { get; set; }
        public string Comments { get; set; }
    }
}