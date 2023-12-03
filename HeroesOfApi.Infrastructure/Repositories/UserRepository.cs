using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HeroesOfApi.Core.Dto;
using HeroesOfApi.Core.Entities;
using HeroesOfApi.Core.Interfaces;
using HeroesOfApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HeroesOfApi.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public UserRepository(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }
    
    public async Task<bool> RegisterAsync(CreateUserDto userDto)
    {
        var existingUser = await _context.Users
            .Where(u => u.Username == userDto.Username || u.Email == userDto.Email)
            .FirstOrDefaultAsync();
        
        if (existingUser != null)
        {
            throw new Exception($"Username or email already exists.");
        }
        
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
        
        var newUser = new User
        {
            UserId = Guid.NewGuid(),
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            Username = userDto.Username,
            Email = userDto.Email,
            PasswordHash = passwordHash
        };
        
        await _context.Users.AddAsync(newUser);
        await _context.SaveChangesAsync();
        return true;
    }
    
    public Task<string> LoginAsync(string username, string password)
    {
        // Create JWT token
        var user = ValidateCredentials(username, password);
        if (user == null) throw new Exception("Invalid credentials.");
        
        var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]!));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        var claimsForToken = new List<Claim>
        {
            new("UserGuid", user.UserId.ToString()),
            new("Username", user.Username),
            new(ClaimTypes.Email, user.Email),
            new("FirstName", user.FirstName),
            new("LastName", user.LastName)
        };

        var token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claimsForToken,
            DateTime.Now,
            expires: DateTime.Now.AddMinutes(5),
            signingCredentials: signingCredentials
        );
        
        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        return Task.FromResult(tokenString);
    }
    
    private User ValidateCredentials(string username, string password)
    {
        var user = _context.Users.FirstOrDefault(u => u.Username == username);
        if (user == null)
        {
            throw new Exception("Invalid credentials.");
        }
        
        if (!VerifyPasswordHash(password, user.PasswordHash))
        {
            throw new Exception("Invalid credentials.");
        }
        
        return user;
    }
    
    private bool VerifyPasswordHash(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }
}