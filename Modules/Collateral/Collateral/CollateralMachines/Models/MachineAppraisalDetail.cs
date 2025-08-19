namespace Collateral.CollateralMachines.Models;

public class MachineAppraisalDetail : Entity<long>
{
    public long CollatId { get; private set; } = default!;
    public long ApprId { get; private set; } = default!;
    public AppraisalDetail AppraisalDetail { get; private set; } = default!;

    private MachineAppraisalDetail() { }

    private MachineAppraisalDetail(
        long collatId,
        long apprId,
        AppraisalDetail appraisalDetail
        
    )
    {
        CollatId = collatId;
        ApprId = apprId;
        AppraisalDetail = appraisalDetail;
    }

    public static MachineAppraisalDetail Create(
        long collatId,
        long apprId,
        AppraisalDetail appraisalDetail
    )
    {
        return new MachineAppraisalDetail(
            collatId,
            apprId,
            appraisalDetail
        );
    }
}