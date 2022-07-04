using EmployeeCrud.Data.Models;

namespace EmployeeCrud.RepositoryPattern;

public interface ISalaryRepository
{
    public Task<List<Salary>> GetAllAsync();

    public Task<Salary?> GetByIdAsync(int id);

    public Task CreateAsync(Salary salary);

    public Task UpdateAsync(Salary salary);

    public Task DeleteAsync(int id);
    Task<bool> Exists(int departmentId);
}