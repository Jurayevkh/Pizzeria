namespace AccountCatalog.Infrastructure.Data;

public class AccountCatalogDbContext : DbContext, IApplicationDbContext
{
    public AccountCatalogDbContext(DbContextOptions<AccountCatalogDbContext> options):base(options)
    {
            
    }

    public DbSet<Categories> Categories { get; set; }
    public DbSet<Customers> Customers { get; set; }
    public DbSet<Products> Products { get; set; }
    public DbSet<Roles> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryTypeConfiguration());
        modelBuilder.ApplyConfiguration(new RoleTypeConfiguration());
    }
}

