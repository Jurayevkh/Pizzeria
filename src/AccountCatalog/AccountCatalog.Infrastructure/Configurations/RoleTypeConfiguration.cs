using AccountCatalog.Domain.Entities.Role;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountCatalog.Infrastructure.Configurations;

public class RoleTypeConfiguration : IEntityTypeConfiguration<Roles>
{
    public void Configure(EntityTypeBuilder<Roles> builder)
    {
        builder.HasData(new Roles { Id = 1, Name = "Admin"},
                        new Roles { Id = 2, Name="Customer"});
    }
}

