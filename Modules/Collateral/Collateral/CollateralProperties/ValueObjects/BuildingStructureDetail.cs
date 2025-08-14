namespace Collateral.CollateralProperties.ValueObjects;

public class BuildingStructureDetail : ValueObject
{
    public BuildingConstructionStyle BuildingConstructionStyle { get; } = default!;
    public BuildingGeneralStructure BuildingGeneralStructure { get; } = default!;
    public BuildingRoofFrame BuildingRoofFrame { get; } = default!;
    public BuildingRoof BuildingRoof { get; } = default!;
    public BuildingCeiling BuildingCeiling { get; } = default!;
    public BuildingWall BuildingWall { get; } = default!;
    public string? Painting { get; }
    public BuildingFence BuildingFence { get; } = default!;
    public BuildingConstructionType ConstType { get; } = default!;

    private BuildingStructureDetail(
        BuildingConstructionStyle buildingConstructionStyle,
        BuildingGeneralStructure buildingGeneralStructure,
        BuildingRoofFrame buildingRoofFrame,
        BuildingRoof buildingRoof,
        BuildingCeiling buildingCeiling,
        BuildingWall buildingWall,
        string? painting,
        BuildingFence buildingFence,
        BuildingConstructionType constType
    )
    {
        BuildingConstructionStyle = buildingConstructionStyle;
        BuildingGeneralStructure = buildingGeneralStructure;
        BuildingRoofFrame = buildingRoofFrame;
        BuildingRoof = buildingRoof;
        BuildingCeiling = buildingCeiling;
        BuildingWall = buildingWall;
        Painting = painting;
        BuildingFence = buildingFence;
        ConstType = constType;
    }

    public static BuildingStructureDetail Create(
        BuildingConstructionStyle buildingConstructionStyle,
        BuildingGeneralStructure buildingGeneralStructure,
        BuildingRoofFrame buildingRoofFrame,
        BuildingRoof buildingRoof,
        BuildingCeiling buildingCeiling,
        BuildingWall buildingWall,
        string? painting,
        BuildingFence buildingFence,
        BuildingConstructionType constType
    )
    {
        return new BuildingStructureDetail(
            buildingConstructionStyle,
            buildingGeneralStructure,
            buildingRoofFrame,
            buildingRoof,
            buildingCeiling,
            buildingWall,
            painting,
            buildingFence,
            constType
        );
    }
}