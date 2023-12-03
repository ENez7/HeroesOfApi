using AutoMapper;
using HeroesOfApi.Core.Dto;
using HeroesOfApi.Core.Entities;

namespace HeroesOfApi.Api.Profiles;

public class HeroProfile : Profile
{
    public HeroProfile()
    {
        CreateMap<CreateHeroDto, Hero>().ReverseMap();
        CreateMap<UpdateHeroDto, Hero>().ReverseMap();
    }
}