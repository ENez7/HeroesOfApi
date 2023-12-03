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
    
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(Hero), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Hero>> GetHeroAsync(int id)
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
}