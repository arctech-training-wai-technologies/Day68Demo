using AutoMapper;
using EmployeeCrud.Data;
using EmployeeCrud.Data.Models;
using EmployeeCrud.RepositoryPattern.RepositoryBase;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace EmployeeCrud.RepositoryPattern;

public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public EmployeeRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<List<TViewModel>> GetSalesEmployeesAboveSalaryLimit<TViewModel>(decimal salaryLimit)
    {
        var employeesQuery = from e in DbSet
            join d in _db.Departments on e.DepartmentRefId equals d.Id
            join s in _db.Salaries on e.Id equals s.EmployeeRefId
            where d.Name == "Sales" && s.Basic >= salaryLimit
            select e;

        return await _mapper.ProjectTo<TViewModel>(employeesQuery).ToListAsync(); employeesQuery.;
    }
}