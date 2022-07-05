using EmployeeCrud.Data.Models;

namespace EmployeeCrud.RepositoryPattern.OldForStudy;

public class MyMongoDbRepositoryOld : IEmployeeRepositoryOld
{
    public Task<List<T>> GetAllAsync<T>()
    {
        throw new NotImplementedException();
    }

    public Task<T?> GetByIdAsync<T>(int id)
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

    public Task<List<Employee>> GetAllAsyncOld()
    {
        throw new NotImplementedException();
    }
}