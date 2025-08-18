namespace Collateral.CollateralProperties.ValueObjects;

public class BuildingConstructionStyle : ValueObject
{
    public string? ConstStyle { get; private set; }
    public string? ConstStyleRemark { get; private set; }

    private BuildingConstructionStyle(string? constStyle, string? constStyleRemark)
    {
        ConstStyle = constStyle;
        ConstStyleRemark = constStyleRemark;
    }

    public static BuildingConstructionStyle Create(string? constStyle, string? constStyleRemark)
    {
        return new BuildingConstructionStyle(constStyle, constStyleRemark);
    }
}
