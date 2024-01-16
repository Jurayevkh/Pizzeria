using AccountCatalog.Domain.Entities.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountCatalog.Infrastructure.Configurations;

public class CategoryTypeConfiguration : IEntityTypeConfiguration<Categories>
{
    public void Configure(EntityTypeBuilder<Categories> builder)
    {
        builder.HasData(new Categories { Id=1,Name="Kombolar"},
            new Categories { Id=2,Name="Pitsalar"},
            new Categories { Id=3,Name="Ichimliklar"},
            new Categories { Id=4,Name="Desertlar"});
    }
}

