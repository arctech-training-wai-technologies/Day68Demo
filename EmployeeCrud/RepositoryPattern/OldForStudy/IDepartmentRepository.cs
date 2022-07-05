using EmployeeCrud.Data.Models;

namespace EmployeeCrud.RepositoryPattern.OldForStudy;

public interface IDepartmentRepositoryOld
{
    public Task<List<T>> GetAllAsync<T>();

    public Task<T?> GetByIdAsync<T>(int id);

    public Task CreateAsync(Department department);

    public Task UpdateAsync(Department department);

    public Task DeleteAsync(int id);
    Task<bool> Exists(int departmentId);
}