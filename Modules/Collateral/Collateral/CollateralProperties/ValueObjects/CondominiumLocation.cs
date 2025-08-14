namespace Collateral.CollateralProperties.ValueObjects;

public class CondominiumLocation : ValueObject
{
    public bool? CondoLocation { get; private set; }
    public string? Street { get; private set; }
    public string? Soi { get; private set; }
    public decimal? Distance { get; private set; }
    public decimal? RoadWidth { get; private set; }
    public decimal? RightOfWay { get; private set; }
    public string? RoadSurface { get; private set; }
    public string? PublicUtility { get; private set; }
    public string? PublicUtilityOther { get; private set; }

    private CondominiumLocation(
        bool? condoLocation,
        string? street,
        string? soi,
        decimal? distance,
        decimal? roadWidth,
        decimal? rightOfWay,
        string? roadSurface,
        string? publicUtility,
        string? publicUtilityOther
    )
    {
        CondoLocation = condoLocation;
        Street = street;
        Soi = soi;
        Distance = distance;
        RoadWidth = roadWidth;
        RightOfWay = rightOfWay;
        RoadSurface = roadSurface;
        PublicUtility = publicUtility;
        PublicUtilityOther = publicUtilityOther;
    }

    public static CondominiumLocation Create(
        bool? condoLocation,
        string? street,
        string? soi,
        decimal? distance,
        decimal? roadWidth,
        decimal? rightOfWay,
        string? roadSurface,
        string? publicUtility,
        string? publicUtilityOther
    )
    {
        return new CondominiumLocation(
            condoLocation,
            street,
            soi,
            distance,
            roadWidth,
            rightOfWay,
            roadSurface,
            publicUtility,
            publicUtilityOther
        );
    }
}