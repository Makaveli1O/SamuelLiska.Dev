using AutoMapper;
using BusinessLayer.Dto.Feature;
using Domain.Entities;

namespace BusinessLayer.Mapping;

public class FeatureMappingProfile : Profile
{
    public FeatureMappingProfile()
    {
        CreateMap<Feature, FeatureViewDto>().ReverseMap();
        CreateMap<Feature, FeatureCreateDto>().ReverseMap();
    }
}
