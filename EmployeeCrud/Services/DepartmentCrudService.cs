using AutoMapper;
using EmployeeCrud.Data.Models;
using EmployeeCrud.RepositoryPattern;
using EmployeeCrud.ViewModel;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EmployeeCrud.Services;

public class DepartmentCrudService : IDepartmentCrudService
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IMapper _mapper;

    public DepartmentCrudService(
        IDepartmentRepository departmentRepository,
        IMapper mapper)
    {
        _departmentRepository = departmentRepository;
        _mapper = mapper;
    }
    public async Task<List<DepartmentViewModel>> GetAllAsync()
    {
        var departments = await _departmentRepository.GetAllAsync<DepartmentViewModel>();

        var departmentViewModels = departments
            .Select(d => _mapper.Map<DepartmentViewModel>(d))
            .ToList();

        return departmentViewModels;
    }

    public async Task<DepartmentViewModel?> GetByIdAsync(int id)
    {
        var department = await _departmentRepository.GetByIdAsync<DepartmentViewModel>(id);

        var departmentViewModel = _mapper.Map<DepartmentViewModel>(department);

        return departmentViewModel;
    }

    public async Task CreateAsync(DepartmentViewModel department)
    {
        var departmentDataModel = _mapper.Map<Department>(department);
        await _departmentRepository.CreateAsync(departmentDataModel);
    }

    public async Task UpdateAsync(DepartmentViewModel department)
    {
        var departmentDataModel = _mapper.Map<Department>(department);
        await _departmentRepository.UpdateAsync(departmentDataModel);
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