
namespace Request.Data.Configurations;

public class RequestPropertyConfiguration : IEntityTypeConfiguration<RequestProperty>
{
    public void Configure(EntityTypeBuilder<RequestProperty> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("PropertyId").UseIdentityColumn();

        builder.Property(p => p.PropertyType).UseCodeConfig().HasColumnName("PropertyType");
        builder.Property(p => p.BuildingType).UseCodeConfig().HasColumnName("BuildingType");
        builder.Property(p => p.SellingPrice).UseMoneyConfig().HasColumnName("SellingPrice");

        builder.OwnsMany(p => p.Titles, title =>
        {
            title.ToTable("RequestTitles");
            title.WithOwner().HasForeignKey("PropertyId");

            title.Property<long>("TitleId");
            title.HasKey("TitleId");

            title.OwnsOne(p => p.Collateral, collateral =>
            {
                collateral.Property(p => p.CollateralType).UseCodeConfig().HasColumnName("CollateralType");
                collateral.Property(p => p.CollateralStatus).HasMaxLength(1).HasColumnName("CollateralStatus");
                collateral.Property(p => p.TitleNo).HasMaxLength(20).HasColumnName("TitleNo");
                collateral.Property(p => p.Owner).HasMaxLength(80).HasColumnName("Owner");
                collateral.Property(p => p.NoOfBuilding).HasColumnName("NoOfBuilding");
                collateral.Property(p => p.TitleDetail).HasMaxLength(200).HasColumnName("TitleDetail");
            });
            
            title.OwnsOne(p => p.Area, area =>
            {
                area.Property(p => p.Rai).HasPrecision(3, 0).HasColumnName("Rai");
                area.Property(p => p.Ngan).HasPrecision(5, 0).HasColumnName("Ngan");
                area.Property(p => p.Wa).HasPrecision(4, 2).HasColumnName("Wa");
                area.Property(p => p.UsageArea).HasPrecision(19, 4).HasColumnName("UsageArea");
            });

            title.OwnsOne(p => p.Condo, condo =>
            {
                condo.Property(p => p.CondoName).HasMaxLength(50).HasColumnName("CondoName");
                condo.Property(p => p.CondoBuildingNo).HasMaxLength(50).HasColumnName("CondoBuildingNo");
                condo.Property(p => p.CondoRoomNo).HasMaxLength(30).HasColumnName("CondoRoomNo");
                condo.Property(p => p.CondoFloorNo).HasMaxLength(10).HasColumnName("CondoFloorNo");
            });

            title.OwnsOne(p => p.TitleAddress, address =>
            {
                address.Property(p => p.HouseNo).HasMaxLength(30).HasColumnName("HouseNo");
                address.Property(p => p.RoomNo).HasMaxLength(30).HasColumnName("RoomNo");
                address.Property(p => p.FloorNo).HasMaxLength(10).HasColumnName("FloorNo");
                address.Property(p => p.BuildingNo).HasMaxLength(50).HasColumnName("BuildingNo");
                address.Property(p => p.Moo).HasMaxLength(50).HasColumnName("Moo");
                address.Property(p => p.Soi).HasMaxLength(50).HasColumnName("Soi");
                address.Property(p => p.Road).HasMaxLength(50).HasColumnName("Road");
                address.Property(p => p.SubDistrict).HasMaxLength(50).HasColumnName("SubDistrict");
                address.Property(p => p.District).HasMaxLength(50).HasColumnName("District");
                address.Property(p => p.Province).HasMaxLength(50).HasColumnName("Province");
                address.Property(p => p.Postcode).UseCodeConfig().HasColumnName("Postcode");
            });

            title.OwnsOne(p => p.DopaAddress, dopaAddress =>
            {
                dopaAddress.Property(p => p.DopaHouseNo).HasMaxLength(30).HasColumnName("DOPAHouseNo");
                dopaAddress.Property(p => p.DopaRoomNo).HasMaxLength(30).HasColumnName("DOPARoomNo");
                dopaAddress.Property(p => p.DopaFloorNo).HasMaxLength(10).HasColumnName("DOPAFloorNo");
                dopaAddress.Property(p => p.DopaBuildingNo).HasMaxLength(50).HasColumnName("DOPABuildingNo");
                dopaAddress.Property(p => p.DopaMoo).HasMaxLength(50).HasColumnName("DOPAMoo");
                dopaAddress.Property(p => p.DopaSoi).HasMaxLength(50).HasColumnName("DOPASoi");
                dopaAddress.Property(p => p.DopaRoad).HasMaxLength(50).HasColumnName("DOPARoad");
                dopaAddress.Property(p => p.DopaSubDistrict).HasMaxLength(50).HasColumnName("DOPASubDistrict");
                dopaAddress.Property(p => p.DopaDistrict).HasMaxLength(50).HasColumnName("DOPADistrict");
                dopaAddress.Property(p => p.DopaProvince).HasMaxLength(50).HasColumnName("DOPAProvince");
                dopaAddress.Property(p => p.DopaPostcode).UseCodeConfig().HasColumnName("DOPAPostcode");
            });

            title.OwnsOne(p => p.Building, building =>
            {
                building.Property(p => p.BuildingType).UseCodeConfig().HasColumnName("BuildingType");
            });

            title.OwnsOne(p => p.Vehicle, vehicle =>
            {
                vehicle.Property(p => p.VehicleType).UseCodeConfig().HasColumnName("VehicleType");
                vehicle.Property(p => p.VehicleRegistrationNo).HasMaxLength(20).HasColumnName("VehicleRegistrationNo");
                vehicle.Property(p => p.VehAppointmentLocation).HasMaxLength(300).HasColumnName("VehAppointmentLocation");
            });

            title.OwnsOne(p => p.Machine, machine =>
            {
                machine.Property(p => p.MachineStatus).UseCodeConfig().HasColumnName("MachineStatus");
                machine.Property(p => p.MachineType).UseCodeConfig().HasColumnName("MachineType");
                machine.Property(p => p.MachineRegistrationStatus).UseCodeConfig().HasColumnName("MachineRegistrationStatus");
                machine.Property(p => p.MachineRegistrationNo).HasMaxLength(50).HasColumnName("MachineRegistrationNo");
                machine.Property(p => p.MachineInvoiceNo).HasMaxLength(20).HasColumnName("MachineInvoiceNo");
                machine.Property(p => p.NoOfMachine).HasPrecision(5, 0).HasColumnName("NoOfMachine");
            });
        });
    }
}