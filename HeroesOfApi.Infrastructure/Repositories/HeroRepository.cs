using HeroesOfApi.Core.Entities;
using HeroesOfApi.Core.Interfaces;
using HeroesOfApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HeroesOfApi.Infrastructure.Repositories;

public class HeroRepository : IHeroRepository
{
    private readonly AppDbContext _context;

    public HeroRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Hero>> GetHeroesAsync()
    {
        return await _context.Heroes.ToListAsync();
    }

    public async Task<Hero> GetHeroAsync(int id)
    {
        var hero = await _context.Heroes.Where(h => h.Id == id).FirstOrDefaultAsync();
        if (hero == null)
        {
            throw new Exception($"Hero with id {id} not found");
        }

        return hero;
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