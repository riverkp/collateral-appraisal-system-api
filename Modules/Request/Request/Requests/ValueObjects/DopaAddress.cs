namespace Request.Requests.ValueObjects;

public record DopaAddress
{
    private DopaAddress(string? dopaHouseNo, string? dopaRoomNo, string? dopaFloorNo, string? dopaBuildingNo, string? dopaMoo,
        string? dopaSoi, string? dopaRoad, string? dopaSubDistrict, string? dopaDistrict, string? dopaProvince,
        string? dopaPostcode)
    {
        DopaHouseNo = dopaHouseNo;
        DopaRoomNo = dopaRoomNo;
        DopaFloorNo = dopaFloorNo;
        DopaBuildingNo = dopaBuildingNo;
        DopaMoo = dopaMoo;
        DopaSoi = dopaSoi;
        DopaRoad = dopaRoad;
        DopaSubDistrict = dopaSubDistrict;
        DopaDistrict = dopaDistrict;
        DopaProvince = dopaProvince;
        DopaPostcode = dopaPostcode;
    }

    public string? DopaHouseNo { get; init; }
    public string? DopaRoomNo { get; init; }
    public string? DopaFloorNo { get; init; }
    public string? DopaBuildingNo { get; init; }
    public string? DopaMoo { get; init; }
    public string? DopaSoi { get; init; }
    public string? DopaRoad { get; init; }
    public string? DopaSubDistrict { get; init; } = default!;
    public string? DopaDistrict { get; init; } = default!;
    public string? DopaProvince { get; init; } = default!;
    public string? DopaPostcode { get; init; }

    public static DopaAddress Create(
        string? dopaHouseNo, string? dopaRoomNo, string? dopaFloorNo, string? dopaBuildingNo, string? dopaMoo,
        string? dopaSoi, string? dopaRoad, string? dopaSubDistrict, string? dopaDistrict, string? dopaProvince,
        string? dopaPostcode)
    {
        return new DopaAddress(dopaHouseNo, dopaRoomNo, dopaFloorNo, dopaBuildingNo,
            dopaMoo, dopaSoi, dopaRoad, dopaSubDistrict, dopaDistrict, dopaProvince,
            dopaPostcode);
    }
}