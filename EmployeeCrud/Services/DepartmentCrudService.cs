using EmployeeCrud.Data.Models;
using EmployeeCrud.RepositoryPattern;

namespace EmployeeCrud.Services;

public class DepartmentCrudService : IDepartmentCrudService
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentCrudService(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }
    public async Task<List<Department>> GetAllAsync()
    {
        return await _departmentRepository.GetAllAsync();
    }

    public async Task<Department?> GetByIdAsync(int id)
    {
        return await _departmentRepository.GetByIdAsync(id);
    }

    public async Task CreateAsync(Department department)
    {
        await _departmentRepository.CreateAsync(department);
    }

    public async Task UpdateAsync(Department department)
    {
        await _departmentRepository.UpdateAsync(department);
    }

    public async Task DeleteAsync(int id)
    {
        await _departmentRepository.DeleteAsync(id);
    }

    public async Task<bool> Exists(int id)
    {
        return await _departmentRepository.Exists(id);
    }
}