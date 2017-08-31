using System;

namespace PTOPlanner.Repository.Domain
{
    public class EmployeePTOBalance
    {
        public int EmployeePTOBalanceID { get; set; }
        public int? EmployeeID { get; set; }
        public DateTime? WeekEnding { get; set; }
        public decimal? PTOBalance { get; set; }
        public decimal? RequestedHours { get; set; }
        public DateTime? Added_DT { get; set; }
        public string Comments { get; set; }
    }
}
