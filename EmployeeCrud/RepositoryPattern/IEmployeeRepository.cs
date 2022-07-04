using EmployeeCrud.Data.Models;

namespace EmployeeCrud.RepositoryPattern;

public interface IEmployeeRepository
{
    public Task<List<Employee>> GetAllAsync();

    public Task<Employee?> GetByIdAsync(int id);

    public Task CreateAsync(Employee employee);

    public Task UpdateAsync(Employee employee);

    public Task DeleteAsync(int id);
    Task<bool> Exists(int employeeId);
}