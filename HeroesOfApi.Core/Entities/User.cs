using System.ComponentModel.DataAnnotations;

namespace HeroesOfApi.Core.Entities;

public class User
{
    public Guid UserId { get; set; }
    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;
    [StringLength(50)]
    public string LastName { get; set; } = string.Empty;
    [StringLength(20)]
    public string Username { get; set; } = string.Empty;
    [StringLength(50)]
    public string Email { get; set; } = string.Empty;
    [StringLength(100)]
    public string PasswordHash { get; set; } = string.Empty;
}