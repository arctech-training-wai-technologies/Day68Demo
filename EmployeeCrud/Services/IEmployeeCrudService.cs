using EmployeeCrud.Data.Models;

namespace EmployeeCrud.Services;

public interface IEmployeeCrudService
{
    public Task<List<Employee>> GetAllAsync();

    public Task<Employee?> GetByIdAsync(int id);
    public Task CreateAsync(Employee employee);
    public Task UpdateAsync(Employee employee);
    public Task DeleteAsync(int id);
    public Task DeleteSelectedEmployees(int[] employeeIds);
    public Task EmailRetiringEmployees();
    Task<bool> Exists(int id);
}