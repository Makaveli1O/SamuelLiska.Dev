using BusinessLayer.Dto.Game;
using AutoMapper;
using Infrastructure.UnitOfWork;
using Domain.Entities;

namespace BusinessLayer.Services;

public class GameService : GenericService<Game, GameViewDto, GameCreateDto>, IGameService
{
    public GameService(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork.GameRepository, unitOfWork, mapper) {}

    protected override GameViewDto MapToViewDto(Game entity) => new()
    {
        Id = entity.Id,
        Title = entity.Title,
        Slug = entity.Slug,
        Description = entity.Description,
        DetailedDescription = entity.DetailedDescription,
        WebGLPath = entity.WebGLPath,
        CoverImagePath = entity.CoverImagePath
    };

    protected override void MapToEntity(GameViewDto dto, Game entity)
    {
        entity.Title = dto.Title;
        entity.Slug = dto.Slug;
        entity.Description = dto.Description;
        entity.DetailedDescription = dto.DetailedDescription;
        entity.WebGLPath = dto.WebGLPath;
        entity.CoverImagePath = dto.CoverImagePath;
    }

    protected override uint GetId(GameViewDto dto) => dto.Id;

    protected override void ValidateCreateDto(GameCreateDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Title))
            throw new ArgumentException("Title is required");

        if (string.IsNullOrWhiteSpace(dto.Slug))
            throw new ArgumentException("Slug is required");
    }

    protected override void ValidateUpdateDto(GameViewDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Title))
            throw new ArgumentException("Title is required");

        if (string.IsNullOrWhiteSpace(dto.Slug))
            throw new ArgumentException("Slug is required");
    }
}