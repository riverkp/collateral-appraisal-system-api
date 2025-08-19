namespace Collateral.Data;

public class CollateralDbContext : DbContext
{
    public CollateralDbContext(DbContextOptions<CollateralDbContext> options) : base(options)
    {
    }

    public DbSet<CollateralMaster> CollateralMasters => Set<CollateralMaster>();
    public DbSet<CollateralMachine> CollateralMachines => Set<CollateralMachine>();
    public DbSet<MachineAppraisalDetail> MachineAppraisalDetails => Set<MachineAppraisalDetail>();
    public DbSet<MachineAppraisalAdditionalInfo> MachineAppraisalAdditionalInfos => Set<MachineAppraisalAdditionalInfo>();
    public DbSet<CollateralVehicle> CollateralVehicles => Set<CollateralVehicle>();
    public DbSet<VehicleAppraisalDetail> VehicleAppraisalDetails => Set<VehicleAppraisalDetail>();
    public DbSet<CollateralVessel> CollateralVessels => Set<CollateralVessel>();
    public DbSet<VesselAppraisalDetail> VesselAppraisalDetails => Set<VesselAppraisalDetail>();
    // public DbSet<CollateralVehicle.Models.CollateralVehicle> CollateralVehicles => Set<CollateralVehicle.Models.CollateralVehicle>();
    // public DbSet<CollateralVessel.Models.CollateralVessel> CollateralVessels => Set<CollateralVessel.Models.CollateralVessel>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure the default schema for the database
        modelBuilder.HasDefaultSchema("collateral");

        // Apply global conventions for the model
        modelBuilder.ApplyGlobalConventions();

        // Apply configurations from the current assembly
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // Call the base method to ensure any additional configurations are applied
        base.OnModelCreating(modelBuilder);
    }
}   