using Collateral.CollateralProperties.ValueObjects;

namespace Collateral.CollateralProperties.Models;

public class BuildingAppraisalDetail : Entity<long>
{
    public long CollatID { get; private set; }
    public long ApprID { get; private set; }
    public BuildingInformation BuildingInformation { get; private set; } = default!;
    public BuildingTypeDetail BuildingTypeDetail { get; private set; } = default!;
    public DecorationDetail DecorationDetail { get; private set; } = default!;
    public Encroachment Encroachment { get; private set; } = default!;
    public BuildingConstructionInformation BuildingConstructionInformation { get; private set; } = default!;
    public string? BuildingMaterial { get; private set; }
    public string? BuildingStyle { get; private set; }
    public RasidentialStatus IsResidential { get; private set; } = default!;
    public BuildingStructureDetail BuildingStructureDetail { get; private set; } = default!;
    public UtilizationDetail UtilizationDetail { get; private set; } = default!;
    public string? Remark { get; private set; }
}