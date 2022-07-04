using EmployeeCrud.Data.Models;

namespace EmployeeCrud.Services;

public interface IDepartmentCrudService
{
    public Task<List<Department>> GetAllAsync();

    public Task<Department?> GetByIdAsync(int id);
    public Task CreateAsync(Department department);
    public Task UpdateAsync(Department department);
    public Task DeleteAsync(int id);
    Task<bool> Exists(int id);
}