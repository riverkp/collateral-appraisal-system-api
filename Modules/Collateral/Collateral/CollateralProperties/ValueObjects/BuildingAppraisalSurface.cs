namespace Collateral.CollateralProperties.ValueObjects;

public class BuildingAppraisalSurface : ValueObject
{
    public decimal? FromFloorNo { get; private set; }
    public decimal? ToFloorNo { get; private set; }
    public string? FloorType { get; private set; }
    public string? FloorStructure { get; private set; }
    public string? FloorStructureOther { get; private set; }
    public string? FloorSurface { get; private set; }
    public string? FloorSurfaceOther { get; private set; }

    private BuildingAppraisalSurface(
        decimal? fromFloorNo,
        decimal? toFloorNo,
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
        decimal? fromFloorNo,
        decimal? toFloorNo,
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