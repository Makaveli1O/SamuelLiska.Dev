using DataAccess.Db;
using Domain.Entities;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;
public class GameRepository : GenericRepository<Game>
{
    public GameRepository(AppDbContext dbContext) : base(dbContext) { }

    public override async Task<IEnumerable<Game>> GetAllAsync()
    {
        return await _dbContext.Games
            .Include(g => g.Features)
            .ToListAsync();
    }

    public override async Task<Game?> GetByIdAsync(uint id)
    {
        return await _dbContext.Games
            .Include(g => g.Features)
            .FirstOrDefaultAsync(g => g.Id == id);
    }
}
