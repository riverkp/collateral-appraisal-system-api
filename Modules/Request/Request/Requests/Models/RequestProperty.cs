namespace Request.Requests.Models;

public class RequestProperty : Entity<long>
{
    private readonly List<RequestTitle> _titles = [];

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

    public IReadOnlyList<RequestTitle> Titles => _titles.AsReadOnly();

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