namespace Collateral.CollateralProperties.ValueObjects;

public class LandMiscellaneousDetail : ValueObject
{
    public decimal? PondArea { get; private set; }
    public decimal? DepthPit { get; private set; }
    public string? HasBuilding { get; private set; }
    public string? HasBuildingOther { get; private set; }

    private LandMiscellaneousDetail(
        decimal? pondArea,
        decimal? depthPit,
        string? hasBuilding,
        string? hasBuildingOther
    )
    {
        PondArea = pondArea;
        DepthPit = depthPit;
        HasBuilding = hasBuilding;
        HasBuildingOther = hasBuildingOther;
    }

    public static LandMiscellaneousDetail Create(
        decimal? pondArea,
        decimal? depthPit,
        string? hasBuilding,
        string? hasBuildingOther
    )
    {
        return new LandMiscellaneousDetail(
            pondArea,
            depthPit,
            hasBuilding,
            hasBuildingOther
        );
    }
}