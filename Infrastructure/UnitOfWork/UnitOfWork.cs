using Infrastructure.Repository;
using Domain.Entities;
using DataAccess.Db;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;
    private GenericRepository<Game> _gameRepository;
    public IGenericRepository<Game> GameRepository => _gameRepository;
    private GenericRepository<Feature> _featureRepository;
    public IGenericRepository<Feature> FeatureRepository => _featureRepository;

    public UnitOfWork(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _gameRepository = new GameRepository(_dbContext);
        _featureRepository = new GenericRepository<Feature>(_dbContext);
    }
    public void Commit()
    {
        _dbContext.SaveChanges();
    }

    public async Task CommitAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public void Rollback() { return; }

    public void Dispose() => _dbContext.Dispose();

    public IGenericRepository<TEntity> GetRepositoryByEntity<TEntity>() where TEntity : class
    {
        if (typeof(TEntity) == typeof(Game))
            return GameRepository as IGenericRepository<TEntity> ?? throw new NotSupportedException($"Repository for {typeof(TEntity).Name} is not registered in UnitOfWork.");
        else if (typeof(TEntity) == typeof(Feature))
            return FeatureRepository as IGenericRepository<TEntity> ?? throw new NotSupportedException($"Repository for {typeof(TEntity).Name} is not registered in UnitOfWork.");

        throw new NotSupportedException($"Repository for {typeof(TEntity).Name} is not registered in UnitOfWork.");
    }
}