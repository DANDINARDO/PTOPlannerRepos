using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTOPlanner.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AnnualPTODays { get; set; }
        public decimal CurrentPTOHrsBalance { get; set; }
        public decimal MaxHrsCarryOver { get; set; }
        public decimal PTOHrsAccrualRate { get; set; }
        public DateTime StartDate { get; set; }
    }
}