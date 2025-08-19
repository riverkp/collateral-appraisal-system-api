namespace Collateral.CollateralProperties.ValueObjects;

public class BuildingConstructionType : ValueObject
{
    public string? ConstType { get; private set; }
    public string? ConstTypeOther { get; private set; }

    private BuildingConstructionType(string? constType, string? constTypeOther)
    {
        ConstType = constType;
        ConstTypeOther = constTypeOther;
    }

    public static BuildingConstructionType Create(string? constType, string? constTypeOther)
    {
        return new BuildingConstructionType(constType, constTypeOther);
    }
}
