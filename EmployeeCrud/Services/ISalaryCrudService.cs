using System.Collections;
using EmployeeCrud.Data.Models;

namespace EmployeeCrud.Services;

public interface ISalaryCrudService
{
    public Task<List<Salary>> GetAllAsync();

    public Task<Salary?> GetByIdAsync(int id);
    public Task CreateAsync(Salary salary);
    public Task UpdateAsync(Salary salary);
    public Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    Task<IEnumerable> GetEmployeeForDropDownAsync();
}