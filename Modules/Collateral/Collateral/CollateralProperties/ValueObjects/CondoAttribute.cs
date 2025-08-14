namespace Collateral.CollateralProperties.ValueObjects;

public class CondoAttribute : ValueObject
{
    public string? Decoration { get; }
    public int? BuildingYear { get; }
    public int CondoHeight { get; }
    public string? BuildingForm { get; }
    public string? ConstMaterial { get; }
    public CondoRoomLayout CondoRoomLayout { get; } = default!;
    public CondoFloor CondoFloor { get; } = default!;
    public BuildingRoof BuildingRoof { get; } = default!;
    public decimal? TotalAreaInSqM { get; }

    private CondoAttribute(
        string? decoration,
        int? buildingYear,
        int condoHeight,
        string? buildingForm,
        string? constMaterial,
        CondoRoomLayout condoRoomLayout,
        CondoFloor condoFloor,
        BuildingRoof buildingRoof,
        decimal? totalAreaInSqM
    )
    {
        Decoration = decoration;
        BuildingYear = buildingYear;
        CondoHeight = condoHeight;
        BuildingForm = buildingForm;
        ConstMaterial = constMaterial;
        CondoRoomLayout = condoRoomLayout;
        CondoFloor = condoFloor;
        BuildingRoof = buildingRoof;
        TotalAreaInSqM = totalAreaInSqM;
    }

    public static CondoAttribute Create(
        string? decoration,
        int? buildingYear,
        int condoHeight,
        string? buildingForm,
        string? constMaterial,
        CondoRoomLayout condoRoomLayout,
        CondoFloor condoFloor,
        BuildingRoof buildingRoof,
        decimal? totalAreaInSqM
    )
    {
        return new CondoAttribute(
            decoration,
            buildingYear,
            condoHeight,
            buildingForm,
            constMaterial,
            condoRoomLayout,
            condoFloor,
            buildingRoof,
            totalAreaInSqM
        );
    }
}