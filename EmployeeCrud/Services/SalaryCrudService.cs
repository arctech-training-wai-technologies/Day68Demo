using System.Collections;
using EmployeeCrud.Data.Models;
using EmployeeCrud.RepositoryPattern;

namespace EmployeeCrud.Services;

public class SalaryCrudService : ISalaryCrudService
{
    private readonly ISalaryRepository _salaryRepository;
    private readonly IEmployeeRepository _employeeRepository;

    public SalaryCrudService(ISalaryRepository salaryRepository, IEmployeeRepository employeeRepository)
    {
        _salaryRepository = salaryRepository;
        _employeeRepository = employeeRepository;
    }
    public async Task<List<Salary>> GetAllAsync()
    {
        return await _salaryRepository.GetAllAsync();
    }

    public async Task<Salary?> GetByIdAsync(int id)
    {
        return await _salaryRepository.GetByIdAsync(id);
    }

    public async Task CreateAsync(Salary department)
    {
        await _salaryRepository.CreateAsync(department);
    }

    public async Task UpdateAsync(Salary department)
    {
        await _salaryRepository.UpdateAsync(department);
    }

    public async Task DeleteAsync(int id)
    {
        await _salaryRepository.DeleteAsync(id);
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _salaryRepository.Exists(id);
    }

    public async Task<IEnumerable> GetEmployeeForDropDownAsync()
    {
        var employees = await _employeeRepository.GetAllAsync();

        var employeesForDropDown = employees.Select(e => new
        {
            Id = e.Id,
            Name = $"{e.Name} ({e.Id})"
        });

        return employeesForDropDown;
    }
}