using Collateral.CollateralProperties.ValueObjects;

namespace Collateral.CollateralProperties.Models;

public class LandAppraisalDetail : Entity<long>
{
    public long CollatId { get; private set; }
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

    private LandAppraisalDetail()
    {
    }

    private LandAppraisalDetail(
        long collatId,
        long apprID,
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
        ApprID = apprID;
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

    public static LandAppraisalDetail Create(
        long collatId,
        long apprID,
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
            apprID,
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
