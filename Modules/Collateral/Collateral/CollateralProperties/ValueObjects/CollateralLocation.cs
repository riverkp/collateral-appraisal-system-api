namespace Collateral.CollateralProperties.ValueObjects;

public class CollateralLocation : ValueObject
{
    public string SubDistrict { get; private set; } = default!;
    public string District { get; private set; } = default!;
    public string Province { get; private set; } = default!;
    public string LandOffice { get; private set; } = default!;

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
