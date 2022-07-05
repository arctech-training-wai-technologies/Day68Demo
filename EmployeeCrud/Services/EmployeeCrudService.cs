using System.Collections;
using AutoMapper;
using EmployeeCrud.Data;
using EmployeeCrud.Data.Models;
using EmployeeCrud.RepositoryPattern;
using EmployeeCrud.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrud.Services;

public class EmployeeCrudService : IEmployeeCrudService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IMapper _mapper;

    public EmployeeCrudService(
        IEmployeeRepository employeeRepository,
        IDepartmentRepository departmentRepository,
        IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _departmentRepository = departmentRepository;
        _mapper = mapper;
    }
    public async Task<List<EmployeeViewModel>> GetAllAsync()
    {
        
        //var employees = await _employeeRepository.GetAllAsyncOld();

        //var employeeViewModelsOld = employees
        //    .Select(e => _mapper.Map<EmployeeViewModel>(e))
        //    .ToList();

        var employeeViewModels = await _employeeRepository.GetAllAsync<EmployeeViewModel>();
        return employeeViewModels;
    }

    public async Task<EmployeeViewModel?> GetByIdAsync(int id)
    {
        var employee = await _employeeRepository.GetByIdAsync<EmployeeViewModel>(id);
        return employee;

        //return _mapper.Map<EmployeeViewModel>(employee);
    }

    public async Task CreateAsync(EmployeeViewModel employee)
    {
        var employeeDataModel = _mapper.Map<Employee>(employee);
        await _employeeRepository.CreateAsync(employeeDataModel);
    }

    public async Task UpdateAsync(EmployeeViewModel employee)
    {
        var employeeDataModel = _mapper.Map<Employee>(employee);
        await _employeeRepository.UpdateAsync(employeeDataModel);
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
        var departments = await _departmentRepository.GetAllAsync<DepartmentDropDownViewModel>();

        return departments;
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
        var employees = await _employeeRepository.GetAllAsync<EmployeeViewModel>();

        var retiringEmployees = employees.Where(e => DateTime.Now.AddYears(-60) > e.DateOfBirth).ToList();

        foreach (var retiringEmployee in retiringEmployees)
        {
            SendEmail(retiringEmployee);
        }
    }

    private void SendEmail(EmployeeViewModel retiringEmployee)
    {
        // Write code to email the employee
    }
}