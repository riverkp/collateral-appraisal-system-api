namespace Collateral.CollateralProperties.ValueObjects;

public class FrontageRoad : ValueObject
{
    public decimal? RoadWidth { get; }
    public decimal? RightOfWay { get; }
    public string? LandAccessibility { get; }
    public string? LandAccessibilityDesc { get; }

    private FrontageRoad(
        decimal? roadWidth,
        decimal? rightOfWay,
        string? landAccessibility,
        string? landAccessibilityDesc
    )
    {
        RoadWidth = roadWidth;
        RightOfWay = rightOfWay;
        LandAccessibility = landAccessibility;
        LandAccessibilityDesc = landAccessibilityDesc;
    }

    public static FrontageRoad Create(
        decimal? roadWidth,
        decimal? rightOfWay,
        string? landAccessibility,
        string? landAccessibilityDesc
    )
    {
        return new FrontageRoad(
            roadWidth,
            rightOfWay,
            landAccessibility,
            landAccessibilityDesc
        );
    }
}