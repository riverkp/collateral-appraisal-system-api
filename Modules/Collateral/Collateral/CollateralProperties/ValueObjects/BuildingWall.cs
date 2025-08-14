namespace Collateral.CollateralProperties.ValueObjects;

public class BuildingWall : ValueObject
{
    public string? InteriorWall { get; private set; }
    public string? InteriorWallOther { get; private set; }
    public string? ExteriorWall { get; private set; }
    public string? ExteriorWallOther { get; private set; }


    private BuildingWall(string? interiorWall, string? interiorWallOther, string? exteriorWall, string? exteriorWallOther)
    {
        InteriorWall = interiorWall;
        InteriorWallOther = interiorWallOther;
        ExteriorWall = exteriorWall;
        ExteriorWallOther = exteriorWallOther;
    }

    public static BuildingWall Create(string? interiorWall, string? interiorWallOther, string? exteriorWall, string? exteriorWallOther)
    {
        return new BuildingWall(interiorWall, interiorWallOther, exteriorWall, exteriorWallOther);
    }
}