using Collateral.CollateralProperties.ValueObjects;

namespace Collateral.CollateralProperties.Models;

public class CollateralCondo : Entity<long>
{
    public long CondoID { get; private set; }
    public long CollateralID { get; private set; }
    public string CondoName { get; private set; } = default!;
    public string BuildingNo { get; private set; } = default!;
    public string ModelName { get; private set; } = default!;
    public string BuiltOnTitleNo { get; private set; } = default!;
    public string CondoRegisNo { get; private set; } = default!;
    public string RoomNo { get; private set; } = default!;
    public int FloorNo { get; private set; }
    public decimal UsableArea { get; private set; }
    public CollateralLocation CollateralLocation { get; private set; } = default!;
    public Coordinate Coordinate { get; private set; } = default!;
    public string Owner { get; private set; } = default!;
}