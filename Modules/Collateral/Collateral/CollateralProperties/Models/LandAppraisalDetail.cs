using Collateral.CollateralProperties.ValueObjects;

namespace Collateral.CollateralProperties.Models;

public class LandAppraisalDetail : Entity<long>
{
    public long CollatId { get; private set; }
    public long ApprId { get; private set; }
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

    private LandAppraisalDetail() { }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("SonarQube", "S107:Methods should not have too many parameters")]
    private LandAppraisalDetail(
        long collatId,
        long apprId,
        ObligationDetail obligationDetail,
        LandLocationDetail landLocationDetail,
        LandFillDetail landFillDetail,
        LandAccessibilityDetail landAccessibilityDetail,
        string? anticipationOfProp,
        LandLimitation landLimitation,
        string? eviction,
        string? allocation,
        ConsecutiveArea consecutiveArea,
        LandMiscellaneousDetail landMiscellaneousDetail
    )
    {
        CollatId = collatId;
        ApprId = apprId;
        ObligationDetail = obligationDetail;
        LandLocationDetail = landLocationDetail;
        LandFillDetail = landFillDetail;
        LandAccessibilityDetail = landAccessibilityDetail;
        AnticipationOfProp = anticipationOfProp;
        LandLimitation = landLimitation;
        Eviction = eviction;
        Allocation = allocation;
        ConsecutiveArea = consecutiveArea;
        LandMiscellaneousDetail = landMiscellaneousDetail;
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("SonarQube", "S107:Methods should not have too many parameters")]
    public static LandAppraisalDetail Create(
        long collatId,
        long apprId,
        ObligationDetail obligationDetail,
        LandLocationDetail landLocationDetail,
        LandFillDetail landFillDetail,
        LandAccessibilityDetail landAccessibilityDetail,
        string? anticipationOfProp,
        LandLimitation landLimitation,
        string? eviction,
        string? allocation,
        ConsecutiveArea consecutiveArea,
        LandMiscellaneousDetail landMiscellaneousDetail
    )
    {
        return new LandAppraisalDetail(
            collatId,
            apprId,
            obligationDetail,
            landLocationDetail,
            landFillDetail,
            landAccessibilityDetail,
            anticipationOfProp,
            landLimitation,
            eviction,
            allocation,
            consecutiveArea,
            landMiscellaneousDetail
        );
    }
}
