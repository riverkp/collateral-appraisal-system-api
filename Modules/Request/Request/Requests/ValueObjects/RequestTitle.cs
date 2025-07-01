namespace Request.Requests.ValueObjects;

public record RequestTitle
{
    public RequestTitle()
    {
    }

    private RequestTitle(
        Collateral collateral,
        Area area,
        Condo condo,
        TitleAddress titleAddress,
        DopaAddress dopaAddress,
        Building building,
        Vehicle vehicle,
        Machine machine
    )
    {
        Collateral = collateral;
        Area = area;
        Condo = condo;
        TitleAddress = titleAddress;
        DopaAddress = dopaAddress;
        Building = building;
        Vehicle = vehicle;
        Machine = machine;
    }

    public Collateral Collateral { get; }
    public Area Area { get; }
    public Condo Condo { get; }
    public TitleAddress TitleAddress { get; }
    public DopaAddress DopaAddress { get; }
    public Building Building { get; }
    public Vehicle Vehicle { get; }
    public Machine Machine { get; }

    public static RequestTitle Of(Collateral collateral, Area area, Condo condo, TitleAddress titleAddress,
        DopaAddress dopaAddress, Building building, Vehicle vehicle, Machine machine)
    {
        ArgumentNullException.ThrowIfNull(collateral);
        ArgumentNullException.ThrowIfNull(area);
        ArgumentNullException.ThrowIfNull(condo);
        ArgumentNullException.ThrowIfNull(titleAddress);
        ArgumentNullException.ThrowIfNull(dopaAddress);
        ArgumentNullException.ThrowIfNull(building);
        ArgumentNullException.ThrowIfNull(vehicle);
        ArgumentNullException.ThrowIfNull(machine);

        return new RequestTitle(collateral, area, condo, titleAddress, dopaAddress, building, vehicle, machine);
    }
}