namespace Request.Requests.ValueObjects;

public record Address
{
    private Address(string? houseNo, string? roomNo, string? floorNo, string? locationIdentifier,
        string? moo, string? soi, string? road, string subDistrict, string district, string province,
        string? postcode)
    {
        HouseNo = houseNo;
        RoomNo = roomNo;
        FloorNo = floorNo;
        LocationIdentifier = locationIdentifier;
        Moo = moo;
        Soi = soi;
        Road = road;
        SubDistrict = subDistrict;
        District = district;
        Province = province;
        Postcode = postcode;
    }

    public string? HouseNo { get; init; }
    public string? RoomNo { get; init; }
    public string? FloorNo { get; init; }
    public string? LocationIdentifier { get; init; }
    public string? Moo { get; init; }
    public string? Soi { get; init; }
    public string? Road { get; init; }
    public string SubDistrict { get; init; } = default!;
    public string District { get; init; } = default!;
    public string Province { get; init; } = default!;
    public string? Postcode { get; init; }

    public static Address Create(
        string? houseNo, string? roomNo, string? floorNo, string? locationIdentifier,
        string? moo, string? soi, string? road, string subDistrict, string district, string province,
        string? postcode)
    {
        return new Address(houseNo, roomNo, floorNo, locationIdentifier,
            moo, soi, road, subDistrict, district, province,
            postcode);
    }
}