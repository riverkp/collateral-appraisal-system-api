namespace Request.Requests.Models;

public class Request : Aggregate<long>
{
    private readonly List<RequestCustomer> _customers = [];
    private readonly List<RequestProperty> _properties = [];

    private Request()
    {
    }

    private Request(string appraisalNo, string status, RequestDetail detail)
    {
        AppraisalNo = appraisalNo;
        Status = status;
        Detail = detail;

        AddDomainEvent(new RequestCreatedEvent(this));
    }

    public string AppraisalNo { get; private set; } = default!;
    public string Status { get; private set; } = default!;
    public RequestDetail Detail { get; private set; } = default!;
    public IReadOnlyList<RequestCustomer> Customers => _customers.AsReadOnly();
    public IReadOnlyList<RequestProperty> Properties => _properties.AsReadOnly();

    // Method
    public static Request From(
        string purpose,
        bool hasAppraisalBook,
        string priority,
        string channel,
        int? occurConstInspec,
        Reference reference,
        LoanDetail loanDetail,
        Address address,
        Contact contact,
        Fee fee,
        Requestor requestor
    )
    {
        var requestDetail = RequestDetail.Of(
            purpose,
            hasAppraisalBook,
            priority,
            channel,
            occurConstInspec,
            new Reference(
                reference.PrevAppraisalNo,
                reference.PrevAppraisalValue,
                reference.PrevAppraisalDate
            ),
            new LoanDetail(
                loanDetail.LoanApplicationNo,
                loanDetail.LimitAmt,
                loanDetail.TotalSellingPrice
            ),
            Address.Create(
                address.HouseNo,
                address.RoomNo,
                address.FloorNo,
                address.LocationIdentifier,
                address.Moo,
                address.Soi,
                address.Road,
                address.SubDistrict,
                address.District,
                address.Province,
                address.Postcode
            ),
            new Contact(
                contact.ContactPersonName,
                contact.ContactPersonContactNo,
                contact.ProjectCode
            ),
            new Fee(
                fee.FeeType,
                fee.FeeRemark
            ),
            Requestor.Create(
                requestor.RequestorEmpId,
                requestor.RequestorName,
                requestor.RequestorEmail,
                requestor.RequestorContactNo,
                requestor.RequestorAo,
                requestor.RequestorBranch,
                requestor.RequestorBusinessUnit,
                requestor.RequestorDepartment,
                requestor.RequestorSection,
                requestor.RequestorCostCenter
            )
        );

        return new Request("67A", "N", requestDetail);
    }

    public void UpdateStatus(string status)
    {
        ArgumentException.ThrowIfNullOrEmpty(status);

        Status = status;
    }

    public void UpdateDetail(
        string purpose,
        bool hasAppraisalBook,
        string priority,
        string channel,
        int? occurConstInspec,
        Reference reference,
        LoanDetail loanDetail,
        Address address,
        Contact contact,
        Fee fee,
        Requestor requestor
    )
    {
        var requestDetail = RequestDetail.Of(
            purpose,
            hasAppraisalBook,
            priority,
            channel,
            occurConstInspec,
            new Reference(
                reference.PrevAppraisalNo,
                reference.PrevAppraisalValue,
                reference.PrevAppraisalDate
            ),
            new LoanDetail(
                loanDetail.LoanApplicationNo,
                loanDetail.LimitAmt,
                loanDetail.TotalSellingPrice
            ),
            Address.Create(
                address.HouseNo,
                address.RoomNo,
                address.FloorNo,
                address.LocationIdentifier,
                address.Moo,
                address.Soi,
                address.Road,
                address.SubDistrict,
                address.District,
                address.Province,
                address.Postcode
            ),
            new Contact(
                contact.ContactPersonName,
                contact.ContactPersonContactNo,
                contact.ProjectCode
            ),
            new Fee(
                fee.FeeType,
                fee.FeeRemark
            ),
            Requestor.Create(
                requestor.RequestorEmpId,
                requestor.RequestorName,
                requestor.RequestorEmail,
                requestor.RequestorContactNo,
                requestor.RequestorAo,
                requestor.RequestorBranch,
                requestor.RequestorBusinessUnit,
                requestor.RequestorDepartment,
                requestor.RequestorSection,
                requestor.RequestorCostCenter
            )
        );

        Detail = requestDetail;
    }

    public void AddCustomer(RequestCustomer customer)
    {
        ArgumentNullException.ThrowIfNull(customer);

        _customers.Add(customer);
    }

    public void AddProperty(RequestProperty property)
    {
        ArgumentNullException.ThrowIfNull(property);

        _properties.Add(property);
    }
}