using About.Domain.Entities.AboutCompany;
using About.Domain.Entities.Actions;
using About.Domain.Entities.Branches;
using About.Domain.Entities.Promocodes;
using Microsoft.EntityFrameworkCore;

namespace About.Application.Abstractions;

public interface IApplicationDbContext
{
    public DbSet<AboutCompany> AboutCompanies { get; set; }
    public DbSet<Actions> Actions { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Promocode> Promocodes { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

}

