using Collateral.CollateralProperties.ValueObjects;

namespace Collateral.CollateralProperties.Models;

public class CollateralLand : Entity<long>
{
    public Coordinate Coordinate { get; private set; } = default!;
    public CollateralLocation CollateralLocation { get; private set; } = default!;
    public string LandDesc { get; private set; } = default!;
    public string Owner { get; private set; } = default!;
}