using EmployeeCrud.Data.Models;
using EmployeeCrud.RepositoryPattern.RepositoryBase;

namespace EmployeeCrud.RepositoryPattern;

public interface IDepartmentRepository : IRepository<Department>
{
    public Task<List<TViewModel>> GetAllWithMoreThan2Employees<TViewModel>();
}