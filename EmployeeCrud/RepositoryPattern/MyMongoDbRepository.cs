using EmployeeCrud.Data.Models;

namespace EmployeeCrud.RepositoryPattern;

public class MyMongoDbRepository : IEmployeeRepository
{
    public Task<List<Employee>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Employee?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(Employee employee)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Employee employee)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Exists(int employeeId)
    {
        throw new NotImplementedException();
    }
}