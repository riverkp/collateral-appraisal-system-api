namespace Collateral.CollateralProperties.Models;

public class CollateralBuilding : Entity<long>
{
    public long CollatID { get; private set; }
    public string BuildingNo { get; private set; } = default!;
    public string ModelName { get; private set; } = default!;
    public string HouseNo { get; private set; } = default!;
    public string BuiltOnTitleNo { get; private set; } = default!;
    public string Owner { get; private set; } = default!;
}