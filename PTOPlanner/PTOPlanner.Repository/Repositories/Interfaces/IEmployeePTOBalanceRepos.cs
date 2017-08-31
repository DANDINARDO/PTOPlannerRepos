using System.Collections.Generic;

namespace PTOPlanner.Repository.Repositories
{
    public interface IEmployeePTOBalanceRepos
    {
        List<Domain.EmployeePTOBalance> GetEmployeePTOBalance();
        Domain.EmployeePTOBalance GetEmployeePTOBalanceById(int Id);
        List<Domain.EmployeePTOBalance> GetEmployeePTOBalanceByEmployeeId(int EmployeeId);
    }
}