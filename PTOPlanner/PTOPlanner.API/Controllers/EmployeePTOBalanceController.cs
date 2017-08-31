﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PTOPlanner.Repository.Domain;
using PTOPlanner.Repository.Domain.RequestObjects;
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
        public EmployeePTOBalance GetById(int Id)
        {
            var employeePTOBalance = _employeePTOBalanceController.GetEmployeePTOBalanceById(Id);
            if (employeePTOBalance == null) throw new HttpResponseException(HttpStatusCode.NoContent);
            return employeePTOBalance;
        }

        /// <summary>
        /// Get EmployeePTOBalances By EmployeeId
        /// </summary>
        /// <returns>EmployeePTOBalance Object</returns>
        [HttpGet]
        public IEnumerable<EmployeePTOBalance> GetByEmployeeId(int Id)
        {
            var employeePTOBalances = _employeePTOBalanceController.GetEmployeePTOBalanceByEmployeeId(Id);
            if (employeePTOBalances == null || employeePTOBalances.Count == 0) throw new HttpResponseException(HttpStatusCode.NoContent);
            return employeePTOBalances;
        }

        /// <summary>
        /// Get EmployeePTOBalances by Request Object
        /// </summary>
        /// <returns>List of EmployeePTOBalance Object</returns>
        [HttpPost]
        public IEnumerable<EmployeePTOBalance> UpdateEmployeePTOBalance(EmployeePTOBalanceRequest employeePTOBalanceRequest)
        {
            var employeePTOBalances = _employeePTOBalanceController.UpdateEmployeePTOBalance(employeePTOBalanceRequest);
            if (employeePTOBalances == null || employeePTOBalances.Count == 0) throw new HttpResponseException(HttpStatusCode.NoContent);
            return employeePTOBalances;
        }
    }
}
