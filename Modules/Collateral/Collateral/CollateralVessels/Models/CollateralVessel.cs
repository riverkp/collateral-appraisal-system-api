namespace Collateral.CollateralVessels.Models;

public class CollateralVessel : Aggregate<long>
{
    public long CollatId { get; private set; } = default!;
    public long ApprId { get; private set; } = default!;
    public CollateralProperty CollateralVesselProperty { get; private set; } = default!;
    public CollateralDetail CollateralVesselDetail { get; private set; } = default!;
    public CollateralSize CollateralVesselSize { get; private set; } = default!;
    public string ChassisNo { get; private set; } = default!;

    private CollateralVessel() { }

    private CollateralVessel(
        long collatId,
        long apprId,
        CollateralProperty collateralVesselProperty,
        CollateralDetail collateralVesselDetail,
        CollateralSize collateralVesselSize,
        string chassisNo
    )
    {
        CollatId = collatId;
        ApprId = apprId;
        CollateralVesselProperty = collateralVesselProperty;
        CollateralVesselDetail = collateralVesselDetail;
        CollateralVesselSize = collateralVesselSize;
        ChassisNo = chassisNo;
    }
    public static CollateralVessel Create(
        long collatId,
        long apprId,
        CollateralProperty collateralVesselProperty,
        CollateralDetail collateralVesselDetail,
        CollateralSize collateralVesselSize,
        string chassisNo
    )
    {
        return new CollateralVessel(
            collatId,
            apprId,
            collateralVesselProperty,
            collateralVesselDetail,
            collateralVesselSize,
            chassisNo
        );
    }
}