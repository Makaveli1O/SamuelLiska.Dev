
using AutoMapper;
using BusinessLayer.Dto.Feature;
using Domain.Entities;
using Infrastructure.UnitOfWork;

namespace BusinessLayer.Services;

public class FeatureService : GenericService<Feature, FeatureViewDto, FeatureCreateDto>
{
    public FeatureService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper){}

    protected override uint GetId(FeatureViewDto dto) => dto.Id;

    protected override void MapToEntity(FeatureViewDto dto, Feature entity)
    {
        entity.Id = dto.Id;
        entity.Name = dto.Name;
    }

    protected override FeatureViewDto MapToViewDto(Feature entity) => new()
    {
        Id = entity.Id,
        Name = entity.Name
    };
}