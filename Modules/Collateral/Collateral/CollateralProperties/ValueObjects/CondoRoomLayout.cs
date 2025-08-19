namespace Collateral.CollateralProperties.ValueObjects;

public class CondoRoomLayout : ValueObject
{
    public string? RoomLayout { get; private set; }
    public string? RoomLayoutOther { get; private set; }

    private CondoRoomLayout(string? roomLayout, string? roomLayoutOther)
    {
        RoomLayout = roomLayout;
        RoomLayoutOther = roomLayoutOther;
    }

    public static CondoRoomLayout Create(string? roomLayout, string? roomLayoutOther)
    {
        return new CondoRoomLayout(roomLayout, roomLayoutOther);
    }
}
