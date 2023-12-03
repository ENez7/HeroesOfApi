using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeroesOfApi.Core.Dto;
using HeroesOfApi.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeroesOfApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] CreateUserDto userDto)
        {
            try
            {
                var result = await _userRepository.RegisterAsync(userDto);
                return Ok(new
                {
                    Created = result
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    e.Message
                });
            }
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginUserDto userDto)
        {
            try
            {
                var token = await _userRepository.LoginAsync(userDto.Username, userDto.Password);
                return Ok(new
                {
                    Token = token
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    e.Message
                });
            }
        }
    }
}
