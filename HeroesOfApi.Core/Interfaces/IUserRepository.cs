using HeroesOfApi.Core.Dto;
using HeroesOfApi.Core.Entities;

namespace HeroesOfApi.Core.Interfaces;

public interface IUserRepository
{
    // Login and register
    public Task<bool> RegisterAsync(CreateUserDto userDto);
    public Task<string> LoginAsync(string username, string password);
}