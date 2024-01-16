using Microsoft.EntityFrameworkCore;
using Order.Application.Abstractions;
using Order.Domain.Entities.Basket;
using Order.Domain.Entities.Order;

namespace Order.Infrastructure.Data;

public class OrderDbContext : DbContext, IApplicationDbContext
{
    public OrderDbContext(DbContextOptions<OrderDbContext> options):base(options)
    {

    }

    public DbSet<BasketItems> BasketItems { get; set; }
    public DbSet<Baskets> Baskets { get; set; }
    public DbSet<Orders> Orders { get; set; }
    public DbSet<OrderItems> OrderItems { get; set; }

}

