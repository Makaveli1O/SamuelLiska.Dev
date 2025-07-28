using DataAccess.Db;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Repository;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
{
    protected readonly AppDbContext _dbContext;

    public GenericRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbContext.Set<TEntity>().ToListAsync();
    }

    public virtual async Task<TEntity?> GetByIdAsync(uint id)
    {
        return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(g => g.Id == id);
    }

    public virtual async Task AddAsync(TEntity entity)
    {
        _dbContext.Set<TEntity>().Add(entity);
        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(TEntity entity)
    {
        _dbContext.Set<TEntity>().Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(uint id)
    {
        var entity = await _dbContext.Set<TEntity>().FindAsync(id);
        if (entity != null)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }

    public virtual async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}