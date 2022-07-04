using EmployeeCrud.Data;
using EmployeeCrud.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrud.RepositoryPattern;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly ApplicationDbContext _context;

    public DepartmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Department>> GetAllAsync()
    {
        return await _context.Departments.ToListAsync();
    }

    public async Task<Department?> GetByIdAsync(int id)
    {
        var department = await _context.Departments
            .FirstOrDefaultAsync(m => m.Id == id);

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