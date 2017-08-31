using System.Collections.Generic;

namespace PTOPlanner.Repository.Repositories
{
    public interface IPayrollScheduleRepos
    {
        /// <summary>
        /// Get All Payroll Schedule
        /// </summary>
        /// <returns>List Of Payroll Schedule Objects</returns>
        List<Domain.PayrollSchedule> GetPayrollSchedules();

        /// <summary>
        /// Create the Payroll Schedule
        /// </summary>
        /// <param name="payrollSchedule">Payroll Schedule Object</param>
        void CreatePayrollSchedule(Domain.PayrollSchedule payrollSchedule);
    }
}