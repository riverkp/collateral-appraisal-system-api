using Collateral.CollateralProperties.Models;

namespace Collateral.Data.Configurations;

public class CollateralCondoConfiguration : IEntityTypeConfiguration<CollateralCondo>
{
    public void Configure(EntityTypeBuilder<CollateralCondo> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).UseIdentityColumn().HasColumnName("CondoId");

        builder
            .HasOne<CollateralMaster>()
            .WithOne(p => p.CollateralCondo)
            .HasForeignKey<CollateralCondo>(p => p.CollatId);

        builder.Property(p => p.CollatId).HasColumnName("CollatId");

        builder.Property(p => p.CondoName).UseLongStringConfig();

        builder.Property(p => p.BuildingNo).UseTinyStringConfig();

        builder.Property(p => p.ModelName).UseLongStringConfig();

        builder.Property(p => p.BuiltOnTitleNo).UseTinyStringConfig();

        builder.Property(p => p.CondoRegisNo).UseVeryShortStringConfig();

        builder.Property(p => p.RoomNo).UseTinyStringConfig();

        builder.Property(p => p.FloorNo);

        builder.Property(p => p.UsableArea).UseAreaConfig();

        builder.OwnsOne(
            p => p.CollateralLocation,
            location =>
            {
                location.Property(p => p.SubDistrict)
                    .UseMediumStringConfig()
                    .HasColumnName("SubDistrict");

                location.Property(p => p.District)
                    .UseMediumStringConfig()
                    .HasColumnName("District");

                location.Property(p => p.Province)
                    .UseMediumStringConfig()
                    .HasColumnName("Province");

                location.Property(p => p.LandOffice)
                    .UseMediumStringConfig()
                    .HasColumnName("LandOffice");
            }
        );

        builder.OwnsOne(
            p => p.Coordinate,
            coordinate =>
            {
                coordinate.Property(p => p.Latitude).UseLatLonConfig().HasColumnName("Latitude");

                coordinate.Property(p => p.Longitude).UseLatLonConfig().HasColumnName("Longitude");
            }
        );

        builder.Property(p => p.Owner).HasMaxLength(50);
    }
}
