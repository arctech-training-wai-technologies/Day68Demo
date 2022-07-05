using AutoMapper;
using EmployeeCrud.Data;
using EmployeeCrud.Data.Models;
using EmployeeCrud.RepositoryPattern.RepositoryBase;
using NuGet.Protocol.Core.Types;

namespace EmployeeCrud.RepositoryPattern;

public class MyMongoDbRepository : Repository<Employee>, IEmployeeRepository
{
    public MyMongoDbRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
    {
    }
}