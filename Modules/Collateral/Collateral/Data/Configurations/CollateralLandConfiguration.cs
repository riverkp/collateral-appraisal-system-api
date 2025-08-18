using Collateral.CollateralProperties.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Collateral.Data.Configurations;

public class CollateralLandConfiguration : IEntityTypeConfiguration<CollateralLand>
{
    public void Configure(EntityTypeBuilder<CollateralLand> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).UseIdentityColumn().HasColumnName("LandId");

        builder
            .HasOne<CollateralMaster.Models.CollateralMaster>()
            .WithOne(p => p.CollateralLand)
            .HasForeignKey<CollateralLand>(p => p.CollatId);

        builder.Property(p => p.CollatId).HasColumnName("CollatID");

        builder.OwnsOne(
            p => p.Coordinate,
            coordinate =>
            {
                coordinate.Property(p => p.Latitude).UseLatLonConfig().HasColumnName("Latitude");

                coordinate.Property(p => p.Longitude).UseLatLonConfig().HasColumnName("Longitude");
            }
        );

        builder.OwnsOne(
            p => p.CollateralLocation,
            location =>
            {
                location
                    .Property(p => p.SubDistrict)
                    .UseMediumStringConfig()
                    .HasColumnName("SubDistrict");

                location
                    .Property(p => p.District)
                    .UseMediumStringConfig()
                    .HasColumnName("District");

                location
                    .Property(p => p.Province)
                    .UseMediumStringConfig()
                    .HasColumnName("Province");

                location.Property(p => p.LandOffice).UseCodeConfig().HasColumnName("LandOffice");
            }
        );

        builder.Property(p => p.LandDesc);

        builder.Property(p => p.Owner).HasMaxLength(80);
    }
}
