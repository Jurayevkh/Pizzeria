using System.Reflection;
using AccountCatalog.Application.Abstractions;
using AccountCatalog.Domain.Entities.Category;
using AccountCatalog.Domain.Entities.Customer;
using AccountCatalog.Domain.Entities.Product;
using AccountCatalog.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AccountCatalog.Infrastructure.Data;

public class AccountCatalogDbContext : DbContext, IApplicationDbContext
{
    public AccountCatalogDbContext(DbContextOptions<AccountCatalogDbContext> options):base(options)
    {
            
    }

    public DbSet<Categories> Categories { get; set; }
    public DbSet<Customers> Customers { get; set; }
    public DbSet<Products> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryTypeConfiguration());
    }
}

