using AutoMapper;
using EmployeeCrud.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrud.RepositoryPattern.RepositoryBase;

public class ViewModelBase
{
    public int Id { get; set; }
}

public class DataModelBase
{
    public int Id { get; set; }
}

public class Repository<TDataModel> : IRepository<TDataModel> where TDataModel: DataModelBase
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;
    protected readonly DbSet<TDataModel> DbSet;

    public Repository(ApplicationDbContext db, IMapper mapper)
    {
        DbSet = db.Set<TDataModel>();
        _db = db;
        _mapper = mapper;
    }

    public async Task<List<TViewModel>> GetAllAsync<TViewModel>()
    {
        var employeeQuery = _mapper
            .ProjectTo<TViewModel>(DbSet);

        return await employeeQuery.ToListAsync();
    }

    public async Task<TViewModel?> GetByIdAsync<TViewModel>(int id) where TViewModel : ViewModelBase
    {
        var employeeQuery = _mapper
            .ProjectTo<TViewModel>(DbSet)
                .Where(m => m.Id == id);

        return await employeeQuery.FirstOrDefaultAsync();
    }

    public async Task CreateAsync(TDataModel entity)
    {
        await DbSet.AddAsync(entity);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(TDataModel entity)
    {
        DbSet.Update(entity);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var employee = await DbSet.FindAsync(id);
        if (employee != null)
        {
            DbSet.Remove(employee);
        }

        await _db.SaveChangesAsync();
    }

    public async Task<bool> Exists(int id)
    {
        return await DbSet.AnyAsync(e => e.Id == id);
    }
}