﻿using EmployeeCrud.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrud.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; } = null!;

    public ApplicationDbContext()
    {}

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}