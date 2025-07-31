using Infrastructure.Repository;
using Domain.Entities;

namespace Infrastructure.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    public IGenericRepository<Game> GameRepository { get; }
    public IGenericRepository<Feature> FeatureRepository{ get; }
    public IGenericRepository<TEntity> GetRepositoryByEntity<TEntity>() where TEntity : class;
    public void Commit();
    public Task CommitAsync();
    public void Rollback();
    new public void Dispose();
}