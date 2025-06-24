namespace Request.Requests.ValueObjects;

public record RequestProperty
{
    public RequestProperty()
    {
    }

    private RequestProperty(
        string propertyType,
        string buildingType,
        decimal? sellingPrice
    )
    {
        PropertyType = propertyType;
        BuildingType = buildingType;
        SellingPrice = sellingPrice;
    }
    public string PropertyType { get; }
    public string BuildingType { get; }
    public decimal? SellingPrice { get; }

    public static RequestProperty Of(
        string propertyType,
        string buildingType,
        decimal? sellingPrice
    )
    {
        ArgumentException.ThrowIfNullOrEmpty(propertyType);
        ArgumentException.ThrowIfNullOrEmpty(buildingType);

        return new RequestProperty(
            propertyType,
            buildingType,
            sellingPrice
        );
    }
}