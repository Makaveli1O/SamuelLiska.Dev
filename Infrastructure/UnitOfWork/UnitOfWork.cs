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
        _gameRepository = new GenericRepository<Game>(_dbContext);
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
}