using EmployeeCrud.Data.Models;

namespace EmployeeCrud.RepositoryPattern.OldForStudy;

public interface IEmployeeRepositoryOld
{
    public Task<List<T>> GetAllAsync<T>();

    public Task<T?> GetByIdAsync<T>(int id);

    public Task CreateAsync(Employee employee);

    public Task UpdateAsync(Employee employee);

    public Task DeleteAsync(int id);
    Task<bool> Exists(int employeeId);
    Task<List<Employee>> GetAllAsyncOld();
}