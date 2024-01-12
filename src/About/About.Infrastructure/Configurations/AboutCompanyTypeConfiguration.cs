using About.Domain.Entities.AboutCompany;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace About.Infrastructure.Configurations;

public class AboutCompanyTypeConfiguration : IEntityTypeConfiguration<AboutCompany>
{
    public void Configure(EntityTypeBuilder<AboutCompany> builder)
    {
        builder.HasData(new AboutCompany { Id=1,Contact="1174",Email="pizzeria@gmail.com",Location="Chilonzor Al-Xorazmiy"});
    }
}

