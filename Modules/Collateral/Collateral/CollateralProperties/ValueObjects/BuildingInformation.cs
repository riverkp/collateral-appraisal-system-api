namespace Collateral.CollateralProperties.ValueObjects;

public class BuildingInformation : ValueObject
{
    public string NoHouseNumber { get; } = default!;
    public decimal? LandArea { get; }
    public decimal? StartingPrice { get; }
    public decimal? FireInsurance { get; }
    public string? BuildingCondition { get; }
    public string? BuildingStatus { get; }
    public DateTime? LicenseExpirationDate { get; }
    public string? IsAppraise { get; }
    public ObligationDetail ObligationDetail { get; private set; } = default!;

    private BuildingInformation(
        string noHouseNumber,
        decimal? landArea,
        decimal? startingPrice,
        decimal? fireInsurance,
        string buildingCondition,
        string buildingStatus,
        DateTime? licenseExpirationDate,
        string isAppraise,
        ObligationDetail obligationDetail
    )
    {
        NoHouseNumber = noHouseNumber;
        LandArea = landArea;
        StartingPrice = startingPrice;
        FireInsurance = fireInsurance;
        BuildingCondition = buildingCondition;
        BuildingStatus = buildingStatus;
        LicenseExpirationDate = licenseExpirationDate;
        IsAppraise = isAppraise;
        ObligationDetail = obligationDetail;
    }

    public static BuildingInformation Create(
        string noHouseNumber,
        decimal? landArea,
        decimal? startingPrice,
        decimal? fireInsurance,
        string buildingCondition,
        string buildingStatus,
        DateTime? licenseExpirationDate,
        string isAppraise,
        ObligationDetail obligationDetail
    )
    {
        return new BuildingInformation(
            noHouseNumber,
            landArea,
            startingPrice,
            fireInsurance,
            buildingCondition,
            buildingStatus,
            licenseExpirationDate,
            isAppraise,
            obligationDetail
        );
    }
}