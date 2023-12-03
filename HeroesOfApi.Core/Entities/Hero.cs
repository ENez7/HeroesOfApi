using System.ComponentModel.DataAnnotations;

namespace HeroesOfApi.Core.Entities;

public class Hero
{
    public int Id { get; set; }
    [StringLength(100)]
    public string HeroName { get; set; } = string.Empty;
    [StringLength(100)]
    public string FirstName { get; set; } = string.Empty;
    [StringLength(100)]
    public string LastName { get; set; } = string.Empty;
    [StringLength(100)]
    public string City { get; set; } = string.Empty;
}