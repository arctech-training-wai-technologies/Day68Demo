using System.Collections;
using EmployeeCrud.Data;
using EmployeeCrud.Data.Models;
using EmployeeCrud.RepositoryPattern;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrud.Services;

public class EmployeeCrudService : IEmployeeCrudService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IDepartmentRepository _departmentRepository;

    public EmployeeCrudService(
        IEmployeeRepository employeeRepository,
        IDepartmentRepository departmentRepository)
    {
        _employeeRepository = employeeRepository;
        _departmentRepository = departmentRepository;
    }
    public async Task<List<Employee>> GetAllAsync()
    {
        return await _employeeRepository.GetAllAsync();
    }

    public async Task<Employee?> GetByIdAsync(int id)
    {
        return await _employeeRepository.GetByIdAsync(id);
    }

    public async Task CreateAsync(Employee employee)
    {
        await _employeeRepository.CreateAsync(employee);
    }

    public async Task UpdateAsync(Employee employee)
    {
        await _employeeRepository.UpdateAsync(employee);
    }

    public async Task DeleteAsync(int id)
    {
        await _employeeRepository.DeleteAsync(id);
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _employeeRepository.Exists(id);
    }

    public async Task<IEnumerable> GetDepartmentListForDropDownAsync()
    {
        return await _departmentRepository.GetAllAsync();
    }

    public async Task DeleteSelectedEmployeesAsync(int[] employeeIds)
    {
        foreach (var employeeId in employeeIds)
        {
            await _employeeRepository.DeleteAsync(employeeId);
        }
    }

    public async Task EmailRetiringEmployeesAsync()
    {
        var employees = await _employeeRepository.GetAllAsync();

        var retiringEmployees = employees.Where(e => DateTime.Now.AddYears(-60) > e.DateOfBirth).ToList();

        foreach (var retiringEmployee in retiringEmployees)
        {
            SendEmail(retiringEmployee);
        }
    }

    private void SendEmail(Employee retiringEmployee)
    {
        // Write code to email the employee
    }
}