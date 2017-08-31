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

        public Domain.EmployeePTOBalance GetEmployeePTOBalance(int Id)
        {
            return ReposGetEmployeePTOBalance(Id);
        }

        #endregion

        #region Private Methods

        private List<Domain.EmployeePTOBalance> ReposGetEmployeePTOBalance()
        {
            var lstEmployeePTOBalance = _dbContext.EmployeePTOBalance.ToList();
            var ptoBalance = _mapper.Map<List<Data.Entities.EmployeePTOBalance>, List<Domain.EmployeePTOBalance>>(lstEmployeePTOBalance);
            return ptoBalance;
        }

        private Domain.EmployeePTOBalance ReposGetEmployeePTOBalance(int Id)
        {
            var employeePTOBalance = _dbContext.EmployeePTOBalance.FirstOrDefault(x => x.EmployeePTOBalanceID == Id);
            var ptoBalance = _mapper.Map<Data.Entities.EmployeePTOBalance, Domain.EmployeePTOBalance>(employeePTOBalance);
            return ptoBalance;
        }

        #endregion
    }
}
