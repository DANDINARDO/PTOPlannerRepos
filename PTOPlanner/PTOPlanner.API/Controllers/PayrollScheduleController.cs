using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PTOPlanner.Repository.Domain;
using PTOPlanner.Repository.Repositories;

namespace PTOPlanner.API.Controllers
{
    public class PayrollScheduleController : ApiController
    {
        private readonly IPayrollScheduleRepos _payrollScheduleRepos;

        public PayrollScheduleController()
        {
            _payrollScheduleRepos =  new PayrollScheduleRepos();
        }

        /// <summary>
        /// Get all Payroll Schedules
        /// </summary>
        /// <returns>List of Payroll Schedules</returns>
        [HttpGet]
        public IEnumerable<PayrollSchedule> Get()
        {
            var payrollSchedules = _payrollScheduleRepos.GetPayrollSchedules();
            if (payrollSchedules == null || payrollSchedules.Count == 0) throw new HttpResponseException(HttpStatusCode.NoContent);
            return payrollSchedules;
        }
    }
}
