using AutoMapper;
using HeroesOfApi.Core.Dto;
using HeroesOfApi.Core.Entities;
using HeroesOfApi.Core.Interfaces;
using HeroesOfApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HeroesOfApi.Infrastructure.Repositories;

public class HeroRepository : IHeroRepository
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public HeroRepository(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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

    public async Task<Hero> CreateHeroAsync(CreateHeroDto hero)
    {
        var existingHero = await _context.Heroes.Where(x => x.HeroName == hero.HeroName).FirstOrDefaultAsync();
        if (existingHero != null)
        {
            throw new Exception($"Hero with name {hero.HeroName} already exists.");
        }
        
        var newHero = _mapper.Map<Hero>(hero);
        _context.Heroes.Update(newHero);
        await _context.SaveChangesAsync();
        return newHero;
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