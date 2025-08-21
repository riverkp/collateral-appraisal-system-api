namespace Appraisal.Appraisals.Models;

public class Appraisal : Aggregate<long>
{
    public long RequestId { get; private set; } = default!;
    public long CollateralId { get; private set; } = default!;

    private Appraisal() { }

    private Appraisal(
        long requestId,
        long collateralId
    )
    {
        RequestId = requestId;
        CollateralId = collateralId;
    }

    public static Appraisal Create(
        long requestId,
        long collateralId
    )
    {
        return new Appraisal(
            requestId,
            collateralId
        );
    }
    
}