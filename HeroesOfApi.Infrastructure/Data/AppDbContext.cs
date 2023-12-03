using HeroesOfApi.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HeroesOfApi.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Hero> Heroes { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
}