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


    public async Task<Hero> UpdateHeroAsync(int id, UpdateHeroDto hero)
    {
        if (id != hero.Id)
        {
            throw new Exception("Id mismatch.");
        }
        var existingHero = await _context.Heroes.FirstOrDefaultAsync(h => h.Id == hero.Id);
        if (existingHero == null)
        {
            throw new Exception($"Hero with id {hero.Id} not found.");
        }
        _mapper.Map(hero, existingHero);
        _context.Heroes.Update(existingHero);
        await _context.SaveChangesAsync();
        return existingHero;
    }

    public async Task DeleteHeroAsync(int id)
    {
        var hero = await _context.Heroes.FirstOrDefaultAsync(h => h.Id == id);
        if (hero == null)
        {
            throw new Exception($"Hero with id {id} not found.");
        }
        _context.Heroes.Remove(hero);
        await _context.SaveChangesAsync();
    }
}