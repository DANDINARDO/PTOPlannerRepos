using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var ptoBalance = _mapper.Map<List<Data.Entities.EmployeePTOBalance>, List<Domain.EmployeePTOBalance>>(lstEmployeePTOBalance);
            return ptoBalance;
        }

        #endregion
    }
}
