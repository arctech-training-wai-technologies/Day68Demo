using EmployeeCrud.Data;
using EmployeeCrud.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrud.RepositoryPattern;

public class SalaryRepository : ISalaryRepository
{
    private readonly ApplicationDbContext _context;

    public SalaryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Salary>> GetAllAsync()
    {
        return await _context.Salaries.Include("EmployeeRef").ToListAsync();
    }

    public async Task<Salary?> GetByIdAsync(int id)
    {
        var salary = await _context.Salaries
            .FirstOrDefaultAsync(m => m.Id == id);

        return salary;
    }

    public async Task CreateAsync(Salary salary)
    {
        _context.Add(salary);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Salary salary)
    {
        _context.Update(salary);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var salary = await _context.Salaries.FindAsync(id);
        if (salary != null)
        {
            _context.Salaries.Remove(salary);
        }

        await _context.SaveChangesAsync();
    }

    public async Task<bool> Exists(int id)
    {
        return await _context.Salaries.AnyAsync(e => e.Id == id);
    }
}