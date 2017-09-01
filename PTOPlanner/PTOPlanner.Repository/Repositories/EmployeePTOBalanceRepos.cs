using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTOPlanner.Data.Entities;
using PTOPlanner.Repository.Domain.RequestObjects;

namespace PTOPlanner.Repository.Repositories
{
    public class EmployeePTOBalanceRepos : RepositoryBase, IEmployeePTOBalanceRepos
    {
        #region Public Methods

        public List<Domain.EmployeePTOBalance> GetEmployeePTOBalance()
        {
            return ReposGetEmployeePTOBalance();
        }

        public Domain.EmployeePTOBalance GetEmployeePTOBalanceById(int Id)
        {
            return ReposGetEmployeePTOBalanceById(Id);
        }

        public List<Domain.EmployeePTOBalance> GetEmployeePTOBalanceByEmployeeId(int EmployeeId)
        {
            return ReposGetEmployeePTOBalanceByEmployeeId(EmployeeId);
        }

        public void UpdateEmployeePTOBalance(int Id, PTOBalanceUpdateRequest ptoBalanceUpdateRequest)
        {
            ReposUpdateEmployeePTOBalanceSPROC(Id, ptoBalanceUpdateRequest);
        }

        public List<Domain.EmployeePTOBalance> GetEmployeePTOBalanceBySPROC(int employeeId, int year)
        {
            return ReposGetEmployeePTOBalanceBySPROC(employeeId, year);
        }

        #endregion

        #region Private Methods

        private List<Domain.EmployeePTOBalance> ReposGetEmployeePTOBalance()
        {
            var lstEmployeePTOBalance = _dbContext.EmployeePTOBalance.ToList();
            var ptoBalance = _mapper.Map<List<Data.Entities.EmployeePTOBalance>, List<Domain.EmployeePTOBalance>>(lstEmployeePTOBalance);
            return ptoBalance;
        }

        private Domain.EmployeePTOBalance ReposGetEmployeePTOBalanceById(int Id)
        {
            var employeePTOBalance = _dbContext.EmployeePTOBalance.FirstOrDefault(x => x.EmployeePTOBalanceID == Id);
            var ptoBalance = _mapper.Map<Data.Entities.EmployeePTOBalance, Domain.EmployeePTOBalance>(employeePTOBalance);
            return ptoBalance;
        }

        private List<Domain.EmployeePTOBalance> ReposGetEmployeePTOBalanceByEmployeeId(int EmployeeId)
        {
            var lstEmployeePTOBalance = _dbContext.EmployeePTOBalance.Where(x => x.EmployeeID == EmployeeId).ToList();
            var ptoBalance = _mapper.Map<List<EmployeePTOBalance>, List<Domain.EmployeePTOBalance>>(lstEmployeePTOBalance);
            return ptoBalance;
        }

        private void ReposUpdateEmployeePTOBalanceSPROC(int Id, PTOBalanceUpdateRequest ptoBalanceUpdateRequest)
        {
            SqlParameter employeeptobalanceid = new SqlParameter("@EmployeePTOBalanceId", Id);
            SqlParameter hrstaken = new SqlParameter("@HrsTaken", ptoBalanceUpdateRequest.HrsTaken);
            SqlParameter comments = new SqlParameter("@Comments", ptoBalanceUpdateRequest.Comments);

            _dbContext.Database.ExecuteSqlCommand("dbo.EmpPTOBalance_Update @EmployeePTOBalanceId, @HrsTaken, @Comments", employeeptobalanceid, hrstaken, comments);
        }

        private List<Domain.EmployeePTOBalance> ReposGetEmployeePTOBalanceBySPROC(int employeeId, int year)
        {
            SqlParameter EmployeeId = new SqlParameter("@EmployeeId", employeeId);
            SqlParameter Year = new SqlParameter("@Year", year);

            var lstEmployeePTOBalance = _dbContext.Database.SqlQuery<CTEmployeePTOBalance>("dbo.EmpPTOBalanceByYear_Get @EmployeeId, @Year", EmployeeId, Year).ToList();
            var ptoBalance = _mapper.Map<List<Data.Entities.CTEmployeePTOBalance>, List<Domain.EmployeePTOBalance>>(lstEmployeePTOBalance);
            return ptoBalance;
        }

        #endregion
    }
}
