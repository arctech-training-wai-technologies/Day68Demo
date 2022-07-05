using System.Collections;
using EmployeeCrud.Data.Models;
using EmployeeCrud.ViewModel;

namespace EmployeeCrud.Services;

public interface IEmployeeCrudService
{
    public Task<List<EmployeeViewModel>> GetAllAsync();

    public Task<EmployeeViewModel?> GetByIdAsync(int id);
    public Task CreateAsync(EmployeeViewModel employee);
    public Task UpdateAsync(EmployeeViewModel employee);
    public Task DeleteAsync(int id);

    public Task DeleteSelectedEmployeesAsync(int[] departmentIds);
    public Task EmailRetiringEmployeesAsync();

    Task<bool> ExistsAsync(int id);
    Task<IEnumerable> GetDepartmentListForDropDownAsync();
}