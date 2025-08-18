using Collateral.CollateralProperties.ValueObjects;

namespace Collateral.CollateralProperties.Models;

public class CondoAppraisalDetail : Entity<long>
{
    public long CollatId { get; private set; }
    public long AppraisalID { get; private set; }
    public ObligationDetail ObligationDetail { get; private set; } = default!;
    public string? DocValidate { get; private set; }
    public CondominiumLocation CondominiumLocation { get; private set; } = default!;
    public CondoAttribute CondoAttribute { get; private set; } = default!;
    public Expropriation Expropriation { get; private set; } = default!;
    public CondominiumFacility CondominiumFacility { get; private set; } = default!;
    public CondoPrice CondoPrice { get; private set; } = default!;
    public ForestBoundary ForestBoundary { get; private set; } = default!;
    public string? Remark { get; private set; }

    // CondoAppraisalAreaDetail
    private readonly List<CondoAppraisalAreaDetail> _condoAppraisalAreaDetails = [];
    public IReadOnlyList<CondoAppraisalAreaDetail> CondoAppraisalAreaDetails => _condoAppraisalAreaDetails.AsReadOnly();

    private CondoAppraisalDetail()
    {
    }

    private CondoAppraisalDetail(
        long collatId,
        long appraisalID,
        ObligationDetail obligationDetail,
        string? docValidate,
        CondominiumLocation condominiumLocation,
        CondoAttribute condoAttribute,
        Expropriation expropriation,
        CondominiumFacility condominiumFacility,
        CondoPrice condoPrice,
        ForestBoundary forestBoundary,
        string? remark
    )
    {
        CollatId = collatId;
        AppraisalID = appraisalID;
        ObligationDetail = obligationDetail;
        DocValidate = docValidate;
        CondominiumLocation = condominiumLocation;
        CondoAttribute = condoAttribute;
        Expropriation = expropriation;
        CondominiumFacility = condominiumFacility;
        CondoPrice = condoPrice;
        ForestBoundary = forestBoundary;
        Remark = remark;
    }

    public static CondoAppraisalDetail Create(
        long collatId,
        long appraisalID,
        ObligationDetail obligationDetail,
        string? docValidate,
        CondominiumLocation condominiumLocation,
        CondoAttribute condoAttribute,
        Expropriation expropriation,
        CondominiumFacility condominiumFacility,
        CondoPrice condoPrice,
        ForestBoundary forestBoundary,
        string? remark
    )
    {
        return new CondoAppraisalDetail(
            collatId,
            appraisalID,
            obligationDetail,
            docValidate,
            condominiumLocation,
            condoAttribute,
            expropriation,
            condominiumFacility,
            condoPrice,
            forestBoundary,
            remark
        );
    }
}
