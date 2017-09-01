using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTOPlanner.Repository.Domain.RequestObjects
{
    public class PTOBalanceRequest
    {
        public int EmployeeId { get; set; }
        public int Year { get; set; }
    }
}
