namespace Collateral.Data.Configurations;

public class CollateralVehicleConfigurations : IEntityTypeConfiguration<CollateralVehicle>
{
    public void Configure(EntityTypeBuilder<CollateralVehicle> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).UseIdentityColumn();
        builder.Property(p => p.Id).HasColumnName("VehicleName");

        builder.HasOne<CollateralMaster>().WithOne(p => p.CollateralVehicle)
            .HasForeignKey<CollateralVehicle>(p => p.CollatId)
            .IsRequired();

        builder.Property(p => p.ChassisNo).HasColumnName("ChassisNo")
            .HasMaxLength(25);

        builder.OwnsOne(p => p.CollateralVehicleProperty, machineProperty =>
        {
            machineProperty.Property(p => p.Name).UseNameConfig()
                .HasColumnName("MachineName");
            machineProperty.Property(p => p.Brand).UseNameConfig()
                .HasColumnName("Brand");
            machineProperty.Property(p => p.Model).UseNameConfig()
                .HasColumnName("Model");
            machineProperty.Property(p => p.EnergyUse).UseMediumStringConfig()
                .HasColumnName("EnergyUse");
        });

        builder.OwnsOne(p => p.CollateralVehicleDetail, machineDetail =>
        {
            machineDetail.Property(p => p.EngineNo).UseShortStringConfig()
                .HasColumnName("EngineNo");
            machineDetail.Property(p => p.RegistrationNo).HasMaxLength(30)
                .HasColumnName("RegistrationNo");
            machineDetail.Property(p => p.YearOfManufacture)
                .HasColumnName("YearOfManufacture");
            machineDetail.Property(p => p.CountryOfManufacture).UseCodeConfig()
                .HasColumnName("CountryOfManufacture");
            machineDetail.Property(p => p.PurchaseDate).HasMaxLength(30)
                .HasColumnName("PurchaseDate");
            machineDetail.Property(p => p.PurchasePrice).HasPrecision(19, 4)
                .HasColumnName("PurchasePrice");
        });

        builder.OwnsOne(p => p.CollateralVehicleSize, machineSize =>
        {
            machineSize.Property(p => p.Capacity).UseMediumStringConfig()
                .HasColumnName("Capacity");
            machineSize.Property(p => p.Width).UseSizeConfig()
                .HasColumnName("Width");
            machineSize.Property(p => p.Length).UseSizeConfig()
                .HasColumnName("Length");
            machineSize.Property(p => p.Height).UseSizeConfig()
                .HasColumnName("Height");
        });
    }
}