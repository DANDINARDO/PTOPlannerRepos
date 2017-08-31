using System.Collections.Generic;
using System.Linq;
using PTOPlanner.Data.Entities;
using PTOPlanner.Repository.Domain;

namespace PTOPlanner.Repository.Repositories
{
    public class PayrollScheduleRepos : RepositoryBase 
    {

        //#region Public Methods

        ///// <summary>
        ///// Get All Payroll Schedule
        ///// </summary>
        ///// <returns>List Of Payroll Schedule Objects</returns>
        //public List<PayrollSchedule> GetPayrollSchedules()
        //{
        //    return ReposGetPayrollSchedules();
        //}

        ///// <summary>
        ///// Create the Payroll Schedule
        ///// </summary>
        ///// <param name="payrollSchedule">Payroll Schedule Object</param>
        //public void CreatePayrollSchedule(PayrollSchedule payrollSchedule)
        //{
        //    ReposCreatePayrollSchedule(payrollSchedule);
        //}

        //#endregion

        //#region Private Methods


        ///// <summary>
        ///// Get All Payroll Schedules
        ///// </summary>
        ///// <returns>List Of Payroll Schedule Objects</returns>
        //private List<PayrollSchedule> ReposGetPayrollSchedules()
        //{
        //    var lstEmployeeInfo = _dbContext.Employee_Info.ToList();
        //    var lstUsers = _mapper.Map<List<Employee_Info>, List<User>>(lstEmployeeInfo);
        //    return lstUsers;
        //}

        ///// <summary>
        ///// Create the User Entity
        ///// </summary>
        ///// <param name="user">User Object</param>
        //private void ReposCreatePayrollSchedule(PayrollSchedule payrollSchedule)
        //{
        //    _dbContext.Employee_Info.Add(_mapper.Map<User, Employee_Info>(user));
        //    _dbContext.SaveChanges();
        //}
    }
}
