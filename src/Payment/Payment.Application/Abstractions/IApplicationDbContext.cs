using Microsoft.EntityFrameworkCore;
using Payment.Domain.Entities.CreditCard;
using Payment.Domain.Entities.Payment;

namespace Payment.Application.Abstractions;

public interface IApplicationDbContext
{
    public DbSet<CreditCards> CreditCards { get; set; }
    public DbSet<Payments> Payments { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

}

