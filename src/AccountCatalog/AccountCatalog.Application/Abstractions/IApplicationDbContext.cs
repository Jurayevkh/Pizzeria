using AccountCatalog.Domain.Entities.Category;
using AccountCatalog.Domain.Entities.Customer;
using AccountCatalog.Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;

namespace AccountCatalog.Application.Abstractions;

public interface IApplicationDbContext
{
    public DbSet<Categories> Categories { get; set; }
    public DbSet<Customers> Customers { get; set; }
    public DbSet<Products> Products { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

