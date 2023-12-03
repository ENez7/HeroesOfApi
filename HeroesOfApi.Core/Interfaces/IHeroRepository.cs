using HeroesOfApi.Core.Dto;
using HeroesOfApi.Core.Entities;

namespace HeroesOfApi.Core.Interfaces;

public interface IHeroRepository
{
    public Task<IEnumerable<Hero>> GetHeroesAsync();
    public Task<Hero> GetHeroAsync(int id);
    public Task<Hero> CreateHeroAsync(CreateHeroDto hero);
    public Task<Hero> UpdateHeroAsync(Hero hero);
    public Task DeleteHeroAsync(int id);
}