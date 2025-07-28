using AutoMapper;
using BusinessLayer.Dto.Game;
using Domain.Entities;

namespace BusinessLayer.Mapping;

public class GameMappingProfile : Profile
{
    public GameMappingProfile()
    {
        CreateMap<Game, GameViewDto>().ReverseMap();
        CreateMap<Game, GameCreateDto>().ReverseMap();
    }
}
