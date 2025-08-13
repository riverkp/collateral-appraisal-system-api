namespace Collateral.CollateralMaster.Models;

public class CollateralMaster : Aggregate<long>
{
    public string CollateralType { get; private set; } = default!;
    public string Description { get; private set; } = default!;

    private CollateralMaster()
    {
    }

    public static CollateralMaster Create(string collateralType, string description)
    {
        ArgumentNullException.ThrowIfNull(collateralType);
        ArgumentNullException.ThrowIfNull(description);

        return new CollateralMaster
        {
            CollateralType = collateralType,
            Description = description,
        };
    }
}