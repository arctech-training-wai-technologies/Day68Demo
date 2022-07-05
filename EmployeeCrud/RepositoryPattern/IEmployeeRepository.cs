using EmployeeCrud.Data.Models;
using EmployeeCrud.RepositoryPattern.RepositoryBase;

namespace EmployeeCrud.RepositoryPattern;

public interface IEmployeeRepository : IRepository<Employee>
{
    public Task<List<TViewModel>> GetSalesEmployeesAboveSalaryLimit<TViewModel>(decimal salaryLimit);
}