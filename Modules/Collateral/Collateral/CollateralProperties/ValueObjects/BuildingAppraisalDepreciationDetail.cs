namespace Collateral.CollateralProperties.ValueObjects;

public class BuildingAppraisalDepreciationDetail : ValueObject
{
    public string AreaDesc { get; } = default!;
    public decimal Area { get; }
    public decimal PricePerSqM { get; }
    public decimal PriceBeforeDegradation { get; }
    public short Year { get; }
    public decimal DegradationYearPct { get; }
    public decimal TotalDegradationPct { get; }
    public decimal PriceDegradation { get; }
    public decimal TotalPrice { get; }
    public bool? AppraisalMethod { get; }

    // BuildingAppraisalDepreciationPeriod
    private readonly List<BuildingAppraisalDepreciationPeriod> _buildingAppraisalDepreciationPeriods =
    [];
    public IReadOnlyList<BuildingAppraisalDepreciationPeriod> BuildingAppraisalDepreciationPeriods =>
        _buildingAppraisalDepreciationPeriods.AsReadOnly();

    private BuildingAppraisalDepreciationDetail(
        string areaDesc,
        decimal area,
        decimal pricePerSqM,
        decimal priceBeforeDegradation,
        short year,
        decimal degradationYearPct,
        decimal totalDegradationPct,
        decimal priceDegradation,
        decimal totalPrice,
        bool? appraisalMethod
    )
    {
        AreaDesc = areaDesc;
        Area = area;
        PricePerSqM = pricePerSqM;
        PriceBeforeDegradation = priceBeforeDegradation;
        Year = year;
        DegradationYearPct = degradationYearPct;
        TotalDegradationPct = totalDegradationPct;
        PriceDegradation = priceDegradation;
        TotalPrice = totalPrice;
        AppraisalMethod = appraisalMethod;
    }

    public static BuildingAppraisalDepreciationDetail Create(
        string areaDesc,
        decimal area,
        decimal pricePerSqM,
        decimal priceBeforeDegradation,
        short year,
        decimal degradationYearPct,
        decimal totalDegradationPct,
        decimal priceDegradation,
        decimal totalPrice,
        bool? appraisalMethod
    )
    {
        return new BuildingAppraisalDepreciationDetail(
            areaDesc,
            area,
            pricePerSqM,
            priceBeforeDegradation,
            year,
            degradationYearPct,
            totalDegradationPct,
            priceDegradation,
            totalPrice,
            appraisalMethod
        );
    }
}
