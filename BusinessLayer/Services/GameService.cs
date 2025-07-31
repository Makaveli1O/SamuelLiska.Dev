using BusinessLayer.Dto.Game;
using AutoMapper;
using Infrastructure.UnitOfWork;
using Domain.Entities;
using BusinessLayer.Dto.Feature;
using Infrastructure.Repository;

namespace BusinessLayer.Services;

public class GameService : GenericService<Game, GameViewDto, GameCreateDto>
{
    private readonly IGenericRepository<Feature> _featureRepository;
    public GameService(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork, mapper)
    {
        _featureRepository = unitOfWork.FeatureRepository;
    }
    public override async Task<GameViewDto> CreateAsync(GameCreateDto dto)
    {
        ValidateCreateDto(dto);
        Game game = _mapper.Map<Game>(dto); // Missing features

        if (dto.FeatureIds.Count != 0)
        {
            foreach (var featureId in dto.FeatureIds)
            {
                Feature? feature = await _featureRepository.GetByIdAsync(featureId);
                if (feature != null) game.Features.Add(feature);
            }
        }

        await _repository.AddAsync(game);
        await SaveAsync();

        return MapToViewDto(game);
    }

    protected override GameViewDto MapToViewDto(Game entity) => new()
    {
        Id = entity.Id,
        Title = entity.Title,
        Slug = entity.Slug,
        Description = entity.Description,
        DetailedDescription = entity.DetailedDescription,
        WebGLPath = entity.WebGLPath,
        CoverImagePath = entity.CoverImagePath,
        Features = _mapper.Map<List<FeatureViewDto>>(entity.Features)
    };

    protected override void MapToEntity(GameViewDto dto, Game entity)
    {
        entity.Title = dto.Title;
        entity.Slug = dto.Slug;
        entity.Description = dto.Description;
        entity.DetailedDescription = dto.DetailedDescription;
        entity.WebGLPath = dto.WebGLPath;
        entity.CoverImagePath = dto.CoverImagePath;
        entity.Features = _mapper.Map<List<Feature>>(dto.Features);
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