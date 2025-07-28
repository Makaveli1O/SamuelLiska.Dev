using Domain.Entities;
namespace Infrastructure.Repository;

public interface IGameRepository
{
    Task<IEnumerable<Game>> GetAllAsync();
    Task<Game?> GetByIdAsync(uint id);
    Task AddAsync(Game game);
    Task UpdateAsync(Game game);
    Task DeleteAsync(uint id);
}
