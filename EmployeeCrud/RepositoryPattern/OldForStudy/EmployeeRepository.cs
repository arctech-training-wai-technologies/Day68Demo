using AutoMapper;
using EmployeeCrud.Data;
using EmployeeCrud.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrud.RepositoryPattern.OldForStudy;

public class EmployeeRepositoryOld : IEmployeeRepositoryOld
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public EmployeeRepositoryOld(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<Employee>> GetAllAsyncOld()
    {
        var employeeQuery = _context
            .Employees
            .Include(nameof(Employee.DepartmentRef));

        return await employeeQuery.ToListAsync();
    }

    public async Task<List<T>> GetAllAsync<T>()
    {
        var employeeQuery = _mapper
            .ProjectTo<T>(_context.Employees);
            
        return await employeeQuery.ToListAsync();
    }

    public async Task<T?> GetByIdAsync<T>(int id)
    {
        //var employee = await _context.Employees.Include(nameof(Employee.DepartmentRef))
        //    .FirstOrDefaultAsync(m => m.Id == id);

        var employeeQuery = _mapper
            .ProjectTo<T>(_context.Employees
                .Where(m => m.Id == id));
            

        return await employeeQuery.FirstOrDefaultAsync(); ;
    }

    public async Task CreateAsync(Employee employee)
    {
        _context.Add(employee);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Employee employee)
    {
        _context.Update(employee);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee != null)
        {
            _context.Employees.Remove(employee);
        }

        await _context.SaveChangesAsync();
    }

    public async Task<bool> Exists(int id)
    {
        return await _context.Employees.AnyAsync(e => e.Id == id);
    }
}