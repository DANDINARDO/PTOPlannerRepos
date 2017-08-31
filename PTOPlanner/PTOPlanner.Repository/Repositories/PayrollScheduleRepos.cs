using System.Collections.Generic;
using System.Linq;
using PTOPlanner.Data.Entities;
using PTOPlanner.Repository.Domain;

namespace PTOPlanner.Repository.Repositories
{
    public class PayrollScheduleRepos : RepositoryBase, IPayrollScheduleRepos
    {

        #region Public Methods

        /// <summary>
        /// Get All Payroll Schedule
        /// </summary>
        /// <returns>List Of Payroll Schedule Objects</returns>
        public List<Domain.PayrollSchedule> GetPayrollSchedules()
        {
            return ReposGetPayrollSchedules();
        }

        /// <summary>
        /// Create the Payroll Schedule
        /// </summary>
        /// <param name="payrollSchedule">Payroll Schedule Object</param>
        public void CreatePayrollSchedule(Domain.PayrollSchedule payrollSchedule)
        {
            ReposCreatePayrollSchedule(payrollSchedule);
        }

        #endregion

        #region Private Methods


        /// <summary>
        /// Get All Payroll Schedule
        /// </summary>
        /// <returns>List Of Payroll Schedule Objects</returns>
        private List<Domain.PayrollSchedule> ReposGetPayrollSchedules()
        {
            var lstPayrollSchedules = _dbContext.PayrollSchedule.ToList();
            var schedules = _mapper.Map<List<Data.Entities.PayrollSchedule>, List<Domain.PayrollSchedule>>(lstPayrollSchedules);
            return schedules;
        }

        /// <summary>
        /// Create the Payroll Schedule
        /// </summary>
        /// <param name="payrollSchedule">Payroll Schedule Object</param>
        private void ReposCreatePayrollSchedule(Domain.PayrollSchedule payrollSchedule)
        {
            _dbContext.PayrollSchedule.Add(_mapper.Map<Domain.PayrollSchedule, Data.Entities.PayrollSchedule>(payrollSchedule));
            _dbContext.SaveChanges();
        }

        #endregion
    }
}
