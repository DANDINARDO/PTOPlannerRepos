using System.Collections.Generic;

namespace PTOPlanner.Repository.Repositories
{
    public interface IEmployeePTOBalanceRepos
    {
        List<Domain.EmployeePTOBalance> GetEmployeePTOBalance();
        Domain.EmployeePTOBalance GetEmployeePTOBalance(int Id);
    }
}