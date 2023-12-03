using System.ComponentModel.DataAnnotations;

namespace HeroesOfApi.Core.Dto;

public class CreateHeroDto
{
    [StringLength(100)]
    public string HeroName { get; set; } = string.Empty;
    [StringLength(100)]
    public string FirstName { get; set; } = string.Empty;
    [StringLength(100)]
    public string LastName { get; set; } = string.Empty;
    [StringLength(100)]
    public string City { get; set; } = string.Empty;
}