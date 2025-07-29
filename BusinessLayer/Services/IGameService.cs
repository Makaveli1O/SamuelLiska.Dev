using BusinessLayer.Dto.Game;

namespace BusinessLayer.Services;

public interface IGameService
{
    Task<IEnumerable<GameViewDto>> GetAllAsync();
    Task<GameViewDto?> GetByIdAsync(uint id);
    Task<GameViewDto> CreateAsync(GameCreateDto dto);
    Task UpdateAsync(GameViewDto dto);
    Task DeleteAsync(uint id);
    Task SaveAsync();
}
