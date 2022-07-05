using AutoMapper;
using EmployeeCrud.Data;
using EmployeeCrud.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrud.RepositoryPattern.OldForStudy;

public class DepartmentRepositoryOld : IDepartmentRepositoryOld
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public DepartmentRepositoryOld(
        ApplicationDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<T>> GetAllAsync<T>()
    {
        //return await _context.Departments.ToListAsync();
        var departmentQuery = _mapper
            .ProjectTo<T>(_context.Departments);

        return await departmentQuery.ToListAsync();
    }

    public async Task<T?> GetByIdAsync<T>(int id)
    {
        //var department = await _context.Departments
        //    .FirstOrDefaultAsync(m => m.Id == id);

        var department = await _mapper
            .ProjectTo<T>(_context.Departments
                .Where(m => m.Id == id))
            .FirstOrDefaultAsync();

        return department;
    }

    public async Task CreateAsync(Department department)
    {
        _context.Add(department);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Department department)
    {
        _context.Update(department);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var department = await _context.Departments.FindAsync(id);
        if (department != null)
        {
            _context.Departments.Remove(department);
        }

        await _context.SaveChangesAsync();
    }

    public async Task<bool> Exists(int id)
    {
        return await _context.Departments.AnyAsync(e => e.Id == id);
    }
}