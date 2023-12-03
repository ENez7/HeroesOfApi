using HeroesOfApi.Core.Dto;

namespace HeroesOfApi.Core.Interfaces;

public interface IUserRepository
{
    public Task<bool> RegisterAsync(CreateUserDto userDto);
    public Task<string> LoginAsync(string username, string password);
}