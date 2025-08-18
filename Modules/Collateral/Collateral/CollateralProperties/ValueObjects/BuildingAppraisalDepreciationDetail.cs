namespace Collateral.CollateralProperties.ValueObjects;

public class BuildingAppraisalDepreciationDetail : ValueObject
{
    public string AreaDesc { get; private set; } = default!;
    public decimal Area { get; private set; }
    public decimal PricePerSqM { get; private set; }
    public decimal PriceBeforeDegradation { get; private set; }
    public short Year { get; private set; }
    public decimal DegradationYearPct { get; private set; }
    public decimal TotalDegradationPct { get; private set; }
    public decimal PriceDegradation { get; private set; }
    public decimal TotalPrice { get; private set; }
    public bool? AppraisalMethod { get; private set; }

    // BuildingAppraisalDepreciationPeriod
    private readonly List<BuildingAppraisalDepreciationPeriod> _buildingAppraisalDepreciationPeriods = [];
    public IReadOnlyList<BuildingAppraisalDepreciationPeriod> BuildingAppraisalDepreciationPeriods => _buildingAppraisalDepreciationPeriods.AsReadOnly();

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