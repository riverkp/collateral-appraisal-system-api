namespace Collateral.CollateralMaster.Models;

public class CollateralMaster : Aggregate<long>
{
    public string CollatType { get; private set; } = default!;
    public long HostCollatID { get; private set; } = default!;

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