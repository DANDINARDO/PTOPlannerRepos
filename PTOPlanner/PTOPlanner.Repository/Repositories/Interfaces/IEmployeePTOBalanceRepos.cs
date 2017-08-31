using System.Collections.Generic;
using PTOPlanner.Repository.Domain.RequestObjects;

namespace PTOPlanner.Repository.Repositories
{
    public interface IEmployeePTOBalanceRepos
    {
        List<Domain.EmployeePTOBalance> GetEmployeePTOBalance();
        Domain.EmployeePTOBalance GetEmployeePTOBalanceById(int Id);
        List<Domain.EmployeePTOBalance> GetEmployeePTOBalanceByEmployeeId(int EmployeeId);
        List<Domain.EmployeePTOBalance> UpdateEmployeePTOBalance(EmployeePTOBalanceRequest balanceRequest);
    }
}