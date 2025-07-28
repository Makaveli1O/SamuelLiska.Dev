namespace Infrastructure.Repository;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(uint id);
    Task AddAsync(TEntity game);
    Task UpdateAsync(TEntity game);
    Task DeleteAsync(uint id);
}