namespace Collateral.CollateralVessels.Models;

public class VesselAppraisalDetail : Entity<long>
{
    public long CollatId { get; private set; } = default!;
    public long ApprId { get; private set; } = default!;
    public AppraisalDetail AppraisalDetail { get; private set; } = default!;

    private VesselAppraisalDetail() { }

    private VesselAppraisalDetail(
        long collatId,
        long apprId,
        AppraisalDetail appraisalDetail
    )
    {
        CollatId = collatId;
        ApprId = apprId;
        AppraisalDetail = appraisalDetail;
    }
    public static VesselAppraisalDetail Create(
        long collatId,
        long apprId,
        AppraisalDetail appraisalDetail
    )
    {
        return new VesselAppraisalDetail(
            collatId,
            apprId,
            appraisalDetail
        );
    }
}