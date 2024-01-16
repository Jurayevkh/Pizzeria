using System.Reflection;
using About.Application.Abstractions;
using About.Domain.Entities.Branches;
using About.Domain.Entities.Promocodes;
using Microsoft.EntityFrameworkCore;

namespace About.Infrastructure.Data;

public class AboutDbContext : DbContext,IApplicationDbContext
{
    public AboutDbContext(DbContextOptions<AboutDbContext> options) : base(options)
    {

    }

    public DbSet<Branch> Branches { get; set; }
    public DbSet<Promocode> Promocodes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetCallingAssembly());
    }
}

