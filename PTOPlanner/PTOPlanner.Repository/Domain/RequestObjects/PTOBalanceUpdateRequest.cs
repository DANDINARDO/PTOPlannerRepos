using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTOPlanner.Repository.Domain.RequestObjects
{
    public class PTOBalanceUpdateRequest
    {
        public decimal HrsTaken { get; set; }
        public string Comments { get; set; }
    }
}
