using DataAccess.Db;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repository;

namespace DataAccess.Repository;

public class GameRepository : IGameRepository
{
    private readonly AppDbContext _db;

    public GameRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Game>> GetAllAsync()
    {
        return await _db.Games.ToListAsync();
    }

    public async Task<Game?> GetByIdAsync(uint id)
    {
        return await _db.Games.FirstOrDefaultAsync(g => g.Id == id);
    }

    public async Task AddAsync(Game game)
    {
        _db.Games.Add(game);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(Game game)
    {
        _db.Games.Update(game);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(uint id)
    {
        var game = await _db.Games.FindAsync(id);
        if (game != null)
        {
            _db.Games.Remove(game);
            await _db.SaveChangesAsync();
        }
    }
}
