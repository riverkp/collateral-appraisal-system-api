namespace Collateral.CollateralProperties.ValueObjects;

public class RasidentialStatus : ValueObject
{
    public string? IsResidential { get; }
    public short? BuildingYear { get; }
    public string? DueTo { get; }

    private RasidentialStatus(string? isResidential, short? buildingYear, string? dueTo)
    {
        IsResidential = isResidential;
        BuildingYear = buildingYear;
        DueTo = dueTo;
    }

    public static RasidentialStatus Create(string? isResidential, short? buildingYear, string? dueTo)
    {
        return new RasidentialStatus(isResidential, buildingYear, dueTo);
    }
}