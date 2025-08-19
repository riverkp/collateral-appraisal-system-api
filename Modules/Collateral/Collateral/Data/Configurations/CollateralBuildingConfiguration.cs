using Collateral.CollateralProperties.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Collateral.Data.Configurations;

public class CollateralBuildingConfiguration : IEntityTypeConfiguration<CollateralBuilding>
{
    public void Configure(EntityTypeBuilder<CollateralBuilding> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).UseIdentityColumn().HasColumnName("BuildingId");

        builder
            .HasOne<CollateralMaster.Models.CollateralMaster>()
            .WithOne(p => p.CollateralBuilding)
            .HasForeignKey<CollateralBuilding>(p => p.CollatId);

        builder.Property(p => p.CollatId).HasColumnName("CollatID");

        builder.Property(p => p.BuildingNo).UseTinyStringConfig();

        builder.Property(p => p.ModelName).UseTinyStringConfig();

        builder.Property(p => p.HouseNo).UseTinyStringConfig();

        builder.Property(p => p.BuiltOnTitleNo).UseTinyStringConfig();

        builder.Property(p => p.Owner).HasMaxLength(30);
    }
}
