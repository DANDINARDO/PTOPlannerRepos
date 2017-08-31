﻿namespace PTOPlanner.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("dbo.PayrollSchedule")]
    public class PayrollSchedule
    {
        public int PayrollScheduleId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? PayDate { get; set; }
    }
}