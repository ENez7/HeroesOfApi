using HeroesOfApi.Core.Dto;
using HeroesOfApi.Core.Entities;
using HeroesOfApi.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace HeroesOfApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HeroController : ControllerBase
{
    private readonly IHeroRepository _heroRepository;

    public HeroController(IHeroRepository heroRepository)
    {
        _heroRepository = heroRepository;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Hero>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Hero>>> GetHeroesAsync()
    {
        var heroes = await _heroRepository.GetHeroesAsync();
        return Ok(heroes);
    }
    
    [HttpGet("{id:int}", Name = "GetHeroAsync")]
    [ProducesResponseType(typeof(Hero), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Hero>> GetHeroAsync([FromRoute]int id)
    {
        try
        {
            var hero = await _heroRepository.GetHeroAsync(id);
            return Ok(hero);
        }
        catch (Exception e)
        {
            Log.Error(e.Message);
            return NotFound(new
            {
                Error = e.Message,
            });
        }
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(Hero), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Hero>> CreateHeroAsync(CreateHeroDto hero)
    {
        try
        {
            var newHero = await _heroRepository.CreateHeroAsync(hero);
            return CreatedAtRoute(nameof(GetHeroAsync), new {id = newHero.Id}, newHero);
        }
        catch (Exception e)
        {
            Log.Error(e.Message);
            return BadRequest(new
            {
                Error = e.Message,
            });
        }
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(Hero), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Hero>> UpdateHeroAsync(int id, UpdateHeroDto hero)
    {
        try
        {
            var updatedHero = await _heroRepository.UpdateHeroAsync(id, hero);
            return Ok(updatedHero);
        }
        catch (Exception e)
        {
            Log.Error(e.Message);
            return NotFound(new
            {
                Error = e.Message,
            });
        }
    }
    
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteHeroAsync(int id)
    {
        try
        {
            await _heroRepository.DeleteHeroAsync(id);
            return NoContent();
        }
        catch (Exception e)
        {
            Log.Error(e.Message);
            return NotFound(new
            {
                Error = e.Message,
            });
        }
    }
}