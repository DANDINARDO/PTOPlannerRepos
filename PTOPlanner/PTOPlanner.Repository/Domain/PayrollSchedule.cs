using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTOPlanner.Repository.Domain
{
    public class PayrollSchedule
    {
        public int PayrollScheduleId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? PayDate { get; set; }
    }
}
