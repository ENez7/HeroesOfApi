using System.ComponentModel.DataAnnotations;

namespace HeroesOfApi.Core.Dto;

public class CreateUserDto
{
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = string.Empty;
    [Required]
    [StringLength(20)]
    public string Username { get; set; } = string.Empty;
    [Required]
    [StringLength(50)]
    public string Email { get; set; } = string.Empty;
    [Required]
    [StringLength(100)]
    public string Password { get; set; } = string.Empty;
}