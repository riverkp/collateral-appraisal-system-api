namespace Collateral.CollateralProperties.ValueObjects;

public class BuildingGeneralStructure : ValueObject
{
    public string? GeneralStructure { get; private set; }
    public string? GeneralStructureOther { get; private set; }

    private BuildingGeneralStructure(string? generalStructure, string? generalStructureOther)
    {
        GeneralStructure = generalStructure;
        GeneralStructureOther = generalStructureOther;
    }

    public static BuildingGeneralStructure Create(
        string? generalStructure,
        string? generalStructureOther
    )
    {
        return new BuildingGeneralStructure(generalStructure, generalStructureOther);
    }
}
