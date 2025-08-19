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
    public CondoRoof CondoRoof { get; } = default!;
    public decimal? TotalAreaInSqM { get; }

    private CondoAttribute() { }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("SonarQube", "S107:Methods should not have too many parameters")]
    private CondoAttribute(
        string? decoration,
        int? buildingYear,
        int condoHeight,
        string? buildingForm,
        string? constMaterial,
        CondoRoomLayout condoRoomLayout,
        CondoFloor condoFloor,
        CondoRoof condoRoof,
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
        CondoRoof = condoRoof;
        TotalAreaInSqM = totalAreaInSqM;
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("SonarQube", "S107:Methods should not have too many parameters")]
    public static CondoAttribute Create(
        string? decoration,
        int? buildingYear,
        int condoHeight,
        string? buildingForm,
        string? constMaterial,
        CondoRoomLayout condoRoomLayout,
        CondoFloor condoFloor,
        CondoRoof condoRoof,
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
            condoRoof,
            totalAreaInSqM
        );
    }
}
