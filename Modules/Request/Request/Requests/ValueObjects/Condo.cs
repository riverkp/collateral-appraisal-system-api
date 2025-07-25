namespace Request.Requests.ValueObjects;

public class Condo : ValueObject
{
    private Condo(string? condoName, string? condoBuildingNo, string? condoRoomNo, string? condoFloorNo)
    {
        CondoName = condoName;
        CondoBuildingNo = condoBuildingNo;
        CondoRoomNo = condoRoomNo;
        CondoFloorNo = condoFloorNo;
    }
    public string? CondoName { get; } = default!;
    public string? CondoBuildingNo { get; } = default!;
    public string? CondoRoomNo { get; } = default!;
    public string? CondoFloorNo { get; } = default!;

    public static Condo Create(string? condoName, string? condoBuildingNo, string? condoRoomNo, string? condoFloorNo)
    {
        return new Condo(condoName, condoBuildingNo, condoRoomNo, condoFloorNo);
    }
}

