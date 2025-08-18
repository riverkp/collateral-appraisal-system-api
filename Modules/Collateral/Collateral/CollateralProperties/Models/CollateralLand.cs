using Collateral.CollateralProperties.ValueObjects;

namespace Collateral.CollateralProperties.Models;

public class CollateralLand : Entity<long>
{
    public long CollatId { get; private set; }
    public Coordinate Coordinate { get; private set; } = default!;
    public CollateralLocation CollateralLocation { get; private set; } = default!;
    public string LandDesc { get; private set; } = default!;
    public string Owner { get; private set; } = default!;

    private CollateralLand()
    {
    }

    private CollateralLand(
        long collatId,
        Coordinate coordinate,
        CollateralLocation collateralLocation,
        string landDesc,
        string owner
    )
    {
        CollatId = collatId;
        Coordinate = coordinate;
        CollateralLocation = collateralLocation;
        LandDesc = landDesc;
        Owner = owner;
    }

    public static CollateralLand Create(
        long collatId,
        Coordinate coordinate,
        CollateralLocation collateralLocation,
        string landDesc,
        string owner
    )
    {
        return new CollateralLand(collatId, coordinate, collateralLocation, landDesc, owner);
    }
}
