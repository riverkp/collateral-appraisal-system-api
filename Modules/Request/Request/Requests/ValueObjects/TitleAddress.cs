namespace Request.Requests.ValueObjects;

public record TitleAddress
{
    private TitleAddress(string? houseNo, string? roomNo, string? floorNo, string? buildingNo,
        string? moo, string? soi, string? road, string subDistrict, string district,
        string province, string? postcode)
    {
        HouseNo = houseNo;
        RoomNo = roomNo;
        FloorNo = floorNo;
        BuildingNo = buildingNo;
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
    public string? BuildingNo { get; init; }
    public string? Moo { get; init; }
    public string? Soi { get; init; }
    public string? Road { get; init; }
    public string SubDistrict { get; init; } = default!;
    public string District { get; init; } = default!;
    public string Province { get; init; } = default!;
    public string? Postcode { get; init; }

    public static TitleAddress Create(
        string? houseNo, string? roomNo, string? floorNo, string? buildingNo,
        string? moo, string? soi, string? road, string subDistrict, string district, string province,
        string? postcode)
    {
        return new TitleAddress(houseNo, roomNo, floorNo, buildingNo,
            moo, soi, road, subDistrict, district, province,
            postcode);
    }
}