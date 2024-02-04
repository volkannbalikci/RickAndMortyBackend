using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RickAndMorty.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Persistence.EntityFramework.Contexts;

public class RickyAndMortyDbContext : DbContext
{
    public const string DEFAULT_SCHEMA = "dbo";
    protected IConfiguration Configuration { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<Episode> Episodes { get; set; }
    public DbSet<Location> Locations { get; set; }

    public RickyAndMortyDbContext(DbContextOptions dbContextOptions, IConfiguration configuration): base(dbContextOptions)
    {
        Configuration = configuration;
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
