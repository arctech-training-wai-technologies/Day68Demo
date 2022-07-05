using EmployeeCrud.ViewModel;

namespace EmployeeCrud.Services;

public interface IDepartmentCrudService
{
    public Task<List<DepartmentViewModel>> GetAllAsync();

    public Task<DepartmentViewModel?> GetByIdAsync(int id);
    public Task CreateAsync(DepartmentViewModel department);
    public Task UpdateAsync(DepartmentViewModel department);
    public Task DeleteAsync(int id);
    Task<bool> Exists(int id);
}