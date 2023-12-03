using HeroesOfApi.Core.Entities;
using HeroesOfApi.Core.Interfaces;

namespace HeroesOfApi.Core.Services;

public class HeroService : IHeroService
{
    public Task<IEnumerable<Hero>> GetHeroesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Hero> GetHeroAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Hero> CreateHeroAsync(Hero hero)
    {
        throw new NotImplementedException();
    }

    public Task<Hero> UpdateHeroAsync(Hero hero)
    {
        throw new NotImplementedException();
    }

    public Task DeleteHeroAsync(int id)
    {
        throw new NotImplementedException();
    }
}