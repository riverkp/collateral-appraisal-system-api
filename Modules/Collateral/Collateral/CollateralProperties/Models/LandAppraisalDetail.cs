using Collateral.CollateralProperties.ValueObjects;

namespace Collateral.CollateralProperties.Models;

public class LandAppraisalDetail : Entity<long>
{
    public long CollatID { get; private set; }
    public long ApprID { get; private set; }
    public ObligationDetail ObligationDetail { get; private set; } = default!;
    public LandLocationDetail LandLocationDetail { get; private set; } = default!;
    public LandFillDetail LandFillDetail { get; private set; } = default!;
    public LandAccessibilityDetail LandAccessibilityDetail { get; private set; } = default!;
    public string? AnticipationOfProp { get; private set; }
    public LandLimitation LandLimitation { get; private set; } = default!;
    public string? Eviction { get; private set; }
    public string? Allocation { get; private set; }
    public ConsecutiveArea ConsecutiveArea { get; private set; } = default!;
    public LandMiscellaneousDetail LandMiscellaneousDetail { get; private set; } = default!;
}