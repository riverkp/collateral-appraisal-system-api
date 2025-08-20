namespace Collateral.CollateralVehicles.Models;

public class VehicleAppraisalDetail : Entity<long>
{
    public long CollatId { get; private set; } = default!;
    public long ApprId { get; private set; } = default!;
    public AppraisalDetail AppraisalDetail { get; private set; } = default!;

    private VehicleAppraisalDetail() { }

    private VehicleAppraisalDetail(
        long collatId,
        long apprId,
        AppraisalDetail appraisalDetail
    )
    {
        CollatId = collatId;
        ApprId = apprId;
        AppraisalDetail = appraisalDetail;
    }

    public static VehicleAppraisalDetail Create(
        long collatId,
        long apprId,
        AppraisalDetail appraisalDetail
    )
    {
        return new VehicleAppraisalDetail(
            collatId,
            apprId,
            appraisalDetail
        );
    }
}