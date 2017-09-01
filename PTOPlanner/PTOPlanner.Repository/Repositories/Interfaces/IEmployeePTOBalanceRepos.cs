using System.Collections.Generic;
using PTOPlanner.Repository.Domain.RequestObjects;

namespace PTOPlanner.Repository.Repositories
{
    public interface IEmployeePTOBalanceRepos
    {
        List<Domain.EmployeePTOBalance> GetEmployeePTOBalance();
        Domain.EmployeePTOBalance GetEmployeePTOBalanceById(int Id);
        List<Domain.EmployeePTOBalance> GetEmployeePTOBalanceByEmployeeId(int EmployeeId);
        void UpdateEmployeePTOBalance(int Id, PTOBalanceUpdateRequest ptoBalanceUpdateRequest);
        List<Domain.EmployeePTOBalance> GetEmployeePTOBalanceBySPROC(int employeeId, int year);
    }
}