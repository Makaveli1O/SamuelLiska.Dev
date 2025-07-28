using BusinessLayer.Dto.Game;
using GameModel = Domain.Entities.Game;
using Infrastructure.Repository;
using AutoMapper;

namespace BusinessLayer.Services;

public class GameService : IGameService
{
    private readonly IGameRepository _repository;
    private readonly IMapper _mapper;

    public GameService(IGameRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GameViewDto>> GetAllAsync()
    {
        IEnumerable<GameModel> games = await _repository.GetAllAsync();

        return games.Select(MapToDto);
    }

    public async Task<GameViewDto?> GetByIdAsync(uint id)
    {
        GameModel game = await _repository.GetByIdAsync(id);
        return game == null ? null : MapToDto(game);
    }

    public async Task<GameViewDto> CreateAsync(GameCreateDto dto)
    {
        Validate(dto);

        var game = _mapper.Map<GameModel>(dto);

        await _repository.AddAsync(game);

        return _mapper.Map<GameViewDto>(game);
    }

    public async Task UpdateAsync(GameViewDto dto)
    {
        Validate(dto);

        var existing = await _repository.GetByIdAsync(dto.Id);
        if (existing == null) throw new InvalidOperationException("Game not found");

        existing.Title = dto.Title;
        existing.Slug = dto.Slug;
        existing.Description = dto.Description;
        existing.WebGLPath = dto.WebGLPath;
        existing.CoverImagePath = dto.CoverImagePath;

        await _repository.UpdateAsync(existing);
    }

    public async Task DeleteAsync(uint id)
    {
        await _repository.DeleteAsync(id);
    }

    private static void Validate(GameCreateDto gameModel)
    {
        if (string.IsNullOrWhiteSpace(gameModel.Title))
            throw new ArgumentException("Title is required");

        if (string.IsNullOrWhiteSpace(gameModel.Slug))
            throw new ArgumentException("Slug is required");
    }

    private static void Validate(GameViewDto gameModel)
    {
        if (string.IsNullOrWhiteSpace(gameModel.Title))
            throw new ArgumentException("Title is required");

        if (string.IsNullOrWhiteSpace(gameModel.Slug))
            throw new ArgumentException("Slug is required");
    }

    private static GameViewDto MapToDto(GameModel model) => new()
    {
        Id = model.Id,
        Title = model.Title,
        Slug = model.Slug,
        Description = model.Description,
        WebGLPath = model.WebGLPath,
        CoverImagePath = model.CoverImagePath
    };
}
