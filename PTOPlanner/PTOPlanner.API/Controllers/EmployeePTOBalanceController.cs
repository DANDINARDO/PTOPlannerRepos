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
    public class EmployeePTOBalanceController : ApiController
    {
        private readonly IEmployeePTOBalanceRepos _employeePTOBalanceController;

        public EmployeePTOBalanceController()
        {
            _employeePTOBalanceController =  new EmployeePTOBalanceRepos();
        }

        /// <summary>
        /// Get all EmployeePTOBalances
        /// </summary>
        /// <returns>List of EmployeePTOBalance Objects</returns>
        [HttpGet]
        public IEnumerable<EmployeePTOBalance> Get()
        {
            var employeePTOBalances = _employeePTOBalanceController.GetEmployeePTOBalance();
            if (employeePTOBalances == null || employeePTOBalances.Count == 0) throw new HttpResponseException(HttpStatusCode.NoContent);
            return employeePTOBalances;
        }

        /// <summary>
        /// Get EmployeePTOBalances By Id
        /// </summary>
        /// <returns>EmployeePTOBalance Object</returns>
        [HttpGet]
        public EmployeePTOBalance Get(int Id)
        {
            var employeePTOBalance = _employeePTOBalanceController.GetEmployeePTOBalance(Id);
            if (employeePTOBalance == null) throw new HttpResponseException(HttpStatusCode.NoContent);
            return employeePTOBalance;
        }
    }
}
