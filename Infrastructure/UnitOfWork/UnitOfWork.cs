using Infrastructure.Repository;
using Domain.Entities;
using DataAccess.Db;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork
{
    private readonly AppDbContext _dbContext;
    private GenericRepository<Game> _gameRepository;
    public IGenericRepository<Game> GameRepository => _gameRepository ?? new GenericRepository<Game>(_dbContext);

    public UnitOfWork(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Commit()
    {
        _dbContext.SaveChanges();
    }

    public async Task CommitAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}