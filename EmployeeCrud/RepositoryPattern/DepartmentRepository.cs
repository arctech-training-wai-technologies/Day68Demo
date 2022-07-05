using AutoMapper;
using EmployeeCrud.Data;
using EmployeeCrud.Data.Models;
using EmployeeCrud.RepositoryPattern.RepositoryBase;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrud.RepositoryPattern;

public class DepartmentRepository : Repository<Department>, IDepartmentRepository
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public DepartmentRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<List<TViewModel>> GetAllWithMoreThan2Employees<TViewModel>()
    {
        var departmentsQuery =
            from e in _db.Employees
            join d in DbSet on e.DepartmentRefId equals d.Id
            group new {e, d} by new {d.Id, d.Name}
            into g
            where g.Count() > 2
            select new
            {
                DepartmentId = g.Key.Id,
                DepartmentName = g.Key.Name,
                EmployeeCount = g.Count()
            };

        return await _mapper.ProjectTo<TViewModel>(departmentsQuery).ToListAsync();
    }
}