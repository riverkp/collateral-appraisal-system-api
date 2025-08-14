namespace Collateral.CollateralProperties.ValueObjects;

public class CondoFloor : ValueObject
{
    public string? GroundFloorMaterial { get; private set; }
    public string? GroundFloorMaterialOther { get; private set; }
    public string? UpperFloorMaterial { get; private set; }
    public string? UpperFloorMaterialOther { get; private set; }
    public string? BathroomFloorMaterial { get; private set; }
    public string? BathroomFloorMaterialOther { get; private set; }

    private CondoFloor(
        string? groundFloorMaterial,
        string? groundFloorMaterialOther,
        string? upperFloorMaterial,
        string? upperFloorMaterialOther,
        string? bathroomFloorMaterial,
        string? bathroomFloorMaterialOther
    )
    {
        GroundFloorMaterial = groundFloorMaterial;
        GroundFloorMaterialOther = groundFloorMaterialOther;
        UpperFloorMaterial = upperFloorMaterial;
        UpperFloorMaterialOther = upperFloorMaterialOther;
        BathroomFloorMaterial = bathroomFloorMaterial;
        BathroomFloorMaterialOther = bathroomFloorMaterialOther;
    }

    public static CondoFloor Create(
        string? groundFloorMaterial,
        string? groundFloorMaterialOther,
        string? upperFloorMaterial,
        string? upperFloorMaterialOther,
        string? bathroomFloorMaterial,
        string? bathroomFloorMaterialOther
    )
    {
        return new CondoFloor(
            groundFloorMaterial,
            groundFloorMaterialOther,
            upperFloorMaterial,
            upperFloorMaterialOther,
            bathroomFloorMaterial,
            bathroomFloorMaterialOther
        );
    }
}