namespace AccountCatalog.Application.Abstractions;

public interface IApplicationDbContext
{
    public DbSet<Categories> Categories { get; set; }
    public DbSet<Customers> Customers { get; set; }
    public DbSet<Products> Products { get; set; }
    public DbSet<Roles> Roles { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

