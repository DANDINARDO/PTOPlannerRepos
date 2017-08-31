﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTOPlanner.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Employee.EmployeePTOBalance")]
    public class EmployeePTOBalance
    {
        [Key]
        public int EmployeePTOBalanceID { get; set; }
        public int? EmployeeID { get; set; }
        public DateTime? WeekEnding { get; set; }
        public decimal? PTOBalance { get; set; }
        public decimal? RequestedHours { get; set; }
        public DateTime? Added_DT { get; set; }
        public string Comments { get; set; }
    }
}
