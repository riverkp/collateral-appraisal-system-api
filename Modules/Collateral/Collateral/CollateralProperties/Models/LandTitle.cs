using Collateral.CollateralProperties.ValueObjects;

namespace Collateral.CollateralProperties.Models;

public class LandTitle : Entity<long>
{
    public long CollatID { get; private set; }
    public int SeqNo { get; private set; }
    public LandTitleDocumentDetail LandTitleDocumentDetail { get; private set; } = default!;
    public LandTitleArea LandTitleArea { get; private set; } = default!;
    public string DocumentType { get; private set; } = default!;
    public string Rawang { get; private set; } = default!;
    public string? AerialPhotoNo { get; private set; }
    public string? BoundaryMarker { get; private set; }
    public string? BoundaryMarkerOther { get; private set; }
    public string DocValidate { get; private set; } = default!;
    public decimal? PricePerSquareWa { get; private set; }
    public decimal? GovernmentPrice { get; private set; }
}