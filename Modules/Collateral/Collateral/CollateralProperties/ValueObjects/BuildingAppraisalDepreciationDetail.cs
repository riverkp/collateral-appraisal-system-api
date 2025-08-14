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
    public string? AppraisalMethod { get; private set; }

    private BuildingAppraisalDepreciationDetail(
        string AreaDesc,
        decimal Area,
        decimal PricePerSqM,
        decimal PriceBeforeDegradation,
        short Year,
        decimal DegradationYearPct,
        decimal TotalDegradationPct,
        decimal PriceDegradation,
        decimal TotalPrice,
        string? AppraisalMethod
    ) {
        this.AreaDesc = AreaDesc;
        this.Area = Area;
        this.PricePerSqM = PricePerSqM;
        this.PriceBeforeDegradation = PriceBeforeDegradation;
        this.Year = Year;
        this.DegradationYearPct = DegradationYearPct;
        this.TotalDegradationPct = TotalDegradationPct;
        this.PriceDegradation = PriceDegradation;
        this.TotalPrice = TotalPrice;
        this.AppraisalMethod = AppraisalMethod;
    }

    public static BuildingAppraisalDepreciationDetail Create(
        string AreaDesc,
        decimal Area,
        decimal PricePerSqM,
        decimal PriceBeforeDegradation,
        short Year,
        decimal DegradationYearPct,
        decimal TotalDegradationPct,
        decimal PriceDegradation,
        decimal TotalPrice,
        string? AppraisalMethod
    ) {
        return new BuildingAppraisalDepreciationDetail(
            AreaDesc,
            Area,
            PricePerSqM,
            PriceBeforeDegradation,
            Year,
            DegradationYearPct,
            TotalDegradationPct,
            PriceDegradation,
            TotalPrice,
            AppraisalMethod
        );
    }
}