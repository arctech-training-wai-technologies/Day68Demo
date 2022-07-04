﻿using EmployeeCrud.Data;
using EmployeeCrud.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrud.RepositoryPattern;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDbContext _context;

    public EmployeeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Employee>> GetAllAsync()
    {
        return await _context.Employees.Include("DepartmentRef").ToListAsync();
    }

    public async Task<Employee?> GetByIdAsync(int id)
    {
        var employee = await _context.Employees
            .FirstOrDefaultAsync(m => m.Id == id);

        return employee;
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