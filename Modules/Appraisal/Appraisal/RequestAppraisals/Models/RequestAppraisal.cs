namespace Appraisal.RequestAppraisals.Models;

public class RequestAppraisal : Aggregate<long>
{
    public long RequestId { get; private set; } = default!;
    public long CollateralId { get; private set; } = default!;

    public MachineAppraisalDetail MachineAppraisalDetails { get; private set; } = default!;
    public MachineAppraisalAdditionalInfo MachineAppraisalAdditionalInfo { get; private set; } = default!;
    public VehicleAppraisalDetail VehicleAppraisalDetail { get; private set; } = default!;
    public VesselAppraisalDetail VesselAppraisalDetail { get; private set; } = default!;
    
    private RequestAppraisal() { }

    private RequestAppraisal(
        long requestId,
        long collateralId
    )
    {
        RequestId = requestId;
        CollateralId = collateralId;
    }

    public static RequestAppraisal Create(
        long requestId,
        long collateralId
    )
    {
        return new RequestAppraisal(
            requestId,
            collateralId
        );
    }
    
}