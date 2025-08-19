namespace Collateral.CollateralMasters.Models;

public class CollateralMaster : Aggregate<long>
{
    public string CollatType { get; private set; } = default!;
    public long HostCollatID { get; private set; } = default!;
    public CollateralMachine CollateralMachine { get; private set; } = default!;
    public MachineAppraisalDetail MachineAppraisalDetail { get; private set; } = default!;
    public CollateralVehicle CollateralVehicle { get; private set; } = default!;
    public VehicleAppraisalDetail VehicleAppraisalDetail { get; private set; } = default!;
    public CollateralVessel CollateralVessel { get; private set; } = default!;
    public VesselAppraisalDetail VesselAppraisalDetail { get; private set; } = default!;

    private CollateralMaster()
    {
    }

    private CollateralMaster(string collateralType, long hostCollateralId)
    {
        ArgumentNullException.ThrowIfNull(collateralType);

        CollatType = collateralType;
        HostCollatID = hostCollateralId;
    }

    public static CollateralMaster Create(string collatType, long hostCollatID)
    {
        ArgumentNullException.ThrowIfNull(collatType);

        return new CollateralMaster(
            collatType,
            hostCollatID
        );
    }
}