namespace Collateral.CollateralProperties.ValueObjects;

public class BuildingAppraisalSurface : ValueObject
{
    public short? FromFloorNo { get; private set; }
    public short? ToFloorNo { get; private set; }
    public string? FloorType { get; private set; }
    public string? FloorStructure { get; private set; }
    public string? FloorStructureOther { get; private set; }
    public string? FloorSurface { get; private set; }
    public string? FloorSurfaceOther { get; private set; }

    private BuildingAppraisalSurface(
        short? fromFloorNo,
        short? toFloorNo,
        string? floorType,
        string? floorStructure,
        string? floorStructureOther,
        string? floorSurface,
        string? floorSurfaceOther
    )
    {
        FromFloorNo = fromFloorNo;
        ToFloorNo = toFloorNo;
        FloorType = floorType;
        FloorStructure = floorStructure;
        FloorStructureOther = floorStructureOther;
        FloorSurface = floorSurface;
        FloorSurfaceOther = floorSurfaceOther;
    }

    public static BuildingAppraisalSurface Create(
        short? fromFloorNo,
        short? toFloorNo,
        string? floorType,
        string? floorStructure,
        string? floorStructureOther,
        string? floorSurface,
        string? floorSurfaceOther
    )
    {
        return new BuildingAppraisalSurface(
            fromFloorNo,
            toFloorNo,
            floorType,
            floorStructure,
            floorStructureOther,
            floorSurface,
            floorSurfaceOther
        );
    }
}
