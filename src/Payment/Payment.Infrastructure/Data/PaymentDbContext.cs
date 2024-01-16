using Microsoft.EntityFrameworkCore;
using Payment.Application.Abstractions;
using Payment.Domain.Entities.CreditCard;
using Payment.Domain.Entities.Payment;

namespace Payment.Infrastructure.Data;

public class PaymentDbContext : DbContext, IApplicationDbContext
{
    public PaymentDbContext(DbContextOptions<PaymentDbContext> options):base(options)
    {

    }

    public DbSet<CreditCards> CreditCards { get; set; }
    public DbSet<Payments> Payments { get; set; }
}

