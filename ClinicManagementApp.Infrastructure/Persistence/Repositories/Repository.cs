using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace ClinicManagementApp.Infrastructure.Persistence.Repositories;
public class Repository<T>(ApplicationDbContext dbContext)
    : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<IEnumerable<T>> GetAllAsync() 
        => await _dbContext.Set<T>().ToListAsync();
    public async Task AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        var entity = await _dbContext.Set<T>().FindAsync(id);

        if(entity is null)
            throw new KeyNotFoundException($"Entity with id {id} not found.");

        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
    public async Task<T?> GetByIdAsync(int id) 
        => await _dbContext.Set<T>().FindAsync(id);
    public async Task<T> UpdateAsync(T entity)
    {
        _dbContext.Set<T>().Update(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }
}