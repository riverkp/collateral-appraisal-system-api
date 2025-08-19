namespace Collateral.CollateralProperties.ValueObjects;

public class CollateralLocation : ValueObject
{
    public string SubDistrict { get; } = default!;
    public string District { get; } = default!;
    public string Province { get; } = default!;
    public string LandOffice { get; } = default!;

    private CollateralLocation(
        string subDistrict,
        string district,
        string province,
        string landOffice
    )
    {
        SubDistrict = subDistrict;
        District = district;
        Province = province;
        LandOffice = landOffice;
    }

    public static CollateralLocation Create(
        string subDistrict,
        string district,
        string province,
        string landOffice
    )
    {
        return new CollateralLocation(subDistrict, district, province, landOffice);
    }
}
