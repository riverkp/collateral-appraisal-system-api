namespace Request.Requests.ValueObjects;

public class Building : ValueObject
{
    public string? BuildingType { get; }

    private Building(string? buildingType)
    {
        BuildingType = buildingType;
    }

    public static Building Create(string? buildingType)
    {
        return new Building(buildingType);
    }
}