using About.Domain.Entities.Branches;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace About.Infrastructure.Configurations;

public class BranchTypeConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.HasData(
            new Branch{ Id=1,Name="Chilonzor",Location="Chilonzor,Shuhrat chorrahasi",WorkSchedule="10:00 - 23:00"},
            new Branch { Id=2,Name="Magic City",Location="Magic City",WorkSchedule="9:00 - 23:45"},
            new Branch { Id=3,Name="MediaPark",Location="Chilonzor , Atlas Sotuv markazi",WorkSchedule="9:00 - 22:00"},
            new Branch { Id=4,Name="Maksim Gorkiy",Location="Mirzo ulug'bek",WorkSchedule="11:00 - 23:00"}
            );
    }
}

