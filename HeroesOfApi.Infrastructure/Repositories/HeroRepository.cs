using HeroesOfApi.Core.Entities;
using HeroesOfApi.Core.Interfaces;
using HeroesOfApi.Infrastructure.Data;

namespace HeroesOfApi.Infrastructure.Repositories;

public class HeroRepository : IHeroRepository
{
    private readonly AppDbContext _context;

    public HeroRepository(AppDbContext context)
    {
        _context = context;
    }
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