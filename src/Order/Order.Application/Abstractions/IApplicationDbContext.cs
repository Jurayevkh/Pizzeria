using Microsoft.EntityFrameworkCore;
using Order.Domain.Entities.Basket;
using Order.Domain.Entities.Order;

namespace Order.Application.Abstractions;

public interface IApplicationDbContext
{
    public DbSet<BasketItems> BasketItems { get; set; }
    public DbSet<Baskets> Baskets { get; set; }
    public DbSet<Orders> Orders { get; set; }
    public DbSet<OrderItems> OrderItems { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

