namespace Collateral.CollateralProperties.ValueObjects;

public class BuildingAppraisalDepreciationPeriod : ValueObject
{
    public int AtYear { get; private set; }
    public decimal DepreciationPerYear { get; private set; }

    private BuildingAppraisalDepreciationPeriod(int atYear, decimal depreciationPerYear)
    {
        AtYear = atYear;
        DepreciationPerYear = depreciationPerYear;
    }

    public static BuildingAppraisalDepreciationPeriod Create(
        int atYear,
        decimal depreciationPerYear
    )
    {
        return new BuildingAppraisalDepreciationPeriod(atYear, depreciationPerYear);
    }
}
