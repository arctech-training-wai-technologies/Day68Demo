using System.Collections;
using EmployeeCrud.Data.Models;

namespace EmployeeCrud.Services;

public interface IEmployeeCrudService
{
    public Task<List<Employee>> GetAllAsync();

    public Task<Employee?> GetByIdAsync(int id);
    public Task CreateAsync(Employee employee);
    public Task UpdateAsync(Employee employee);
    public Task DeleteAsync(int id);

    public Task DeleteSelectedEmployeesAsync(int[] departmentIds);
    public Task EmailRetiringEmployeesAsync();

    Task<bool> ExistsAsync(int id);
    Task<IEnumerable> GetDepartmentListForDropDownAsync();
}