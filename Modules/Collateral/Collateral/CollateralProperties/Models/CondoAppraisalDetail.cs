using Collateral.CollateralProperties.ValueObjects;

namespace Collateral.CollateralProperties.Models;

public class CondoAppraisalDetail : Entity<long>
{
    public long CondoApprID { get; private set; }
    public long CollateralID { get; private set; }
    public long AppraisalID { get; private set; }
    public ObligationDetail ObligationDetail { get; private set; } = default!;
    public string? DocValidate { get; private set; }
    public CondominiumLocation CondominiumLocation { get; private set; } = default!;
    public CondoAttribute CondoAttribute { get; private set; } = default!;
    public Expropriation Expropriation { get; private set; } = default!;
    public CondominiumFacility CondominiumFacility { get; private set; } = default!;
    public CondoPrice CondoPrice { get; private set; } = default!;
    public ForestBoundary ForestBoundary { get; private set; } = default!;
    public string? Remark { get; private set; }
}