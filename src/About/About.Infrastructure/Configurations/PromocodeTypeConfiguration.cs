using About.Domain.Entities.Promocodes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace About.Infrastructure.Configurations;

public class PromocodeTypeConfiguration : IEntityTypeConfiguration<Promocode>
{
    public void Configure(EntityTypeBuilder<Promocode> builder)
    {
        builder.HasData(
            new Promocode { Id=1,Promokod="2024",Sum=30000,ExpiryDate=DateTime.Now+TimeSpan.FromDays(5)},
            new Promocode { Id=2,Promokod="Milliy",Sum=15000,ExpiryDate=DateTime.Now+TimeSpan.FromDays(4)}
            );
    }
}

