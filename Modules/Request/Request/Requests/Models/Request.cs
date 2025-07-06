namespace Request.Requests.Models;

public class Request : Aggregate<long>
{
    public AppraisalNumber AppraisalNo { get; private set; } = default!;
    public RequestStatus Status { get; private set; } = default!;
    public RequestDetail Detail { get; private set; } = default!;

    private readonly List<RequestCustomer> _customers = [];
    private readonly List<RequestProperty> _properties = [];
    private readonly List<RequestComment> _comments = [];
    public IReadOnlyList<RequestCustomer> Customers => _customers.AsReadOnly();
    public IReadOnlyList<RequestProperty> Properties => _properties.AsReadOnly();
    public IReadOnlyList<RequestComment> Comments => _comments.AsReadOnly();

    private Request()
    {
        // For EF Core
    }

    private Request(AppraisalNumber appraisalNo, RequestStatus status, RequestDetail detail)
    {
        AppraisalNo = appraisalNo;
        Status = status;
        Detail = detail;

        AddDomainEvent(new RequestCreatedEvent(this));
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("SonarQube", "S107:Methods should not have too many parameters")]
    public static Request Create(
        AppraisalNumber appraisalNo,
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
        var requestDetail = RequestDetail.Create(
            purpose,
            hasAppraisalBook,
            priority,
            channel,
            occurConstInspec,
            reference,
            loanDetail,
            address,
            contact,
            fee,
            requestor
        );

        return new Request(appraisalNo, RequestStatus.New, requestDetail);
    }

    private void UpdateStatus(RequestStatus status)
    {
        ArgumentNullException.ThrowIfNull(status);

        Status = status;
    }

    public void SaveDraft()
    {
        UpdateStatus(RequestStatus.Draft);
    }

    public void Submit()
    {
        UpdateStatus(RequestStatus.New);
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("SonarQube", "S107:Methods should not have too many parameters")]
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
        if (Status != RequestStatus.Draft && Status != RequestStatus.New)
        {
            throw new InvalidOperationException("Cannot update request details when the status is not Draft or New.");
        }

        var newDetail = RequestDetail.Create(
            purpose,
            hasAppraisalBook,
            priority,
            channel,
            occurConstInspec,
            reference,
            loanDetail,
            address,
            contact,
            fee,
            requestor
        );

        if (!Detail.Equals(newDetail))
        {
            Detail = newDetail;
        }
    }

    public void UpdateCustomers(List<RequestCustomer> customers)
    {
        if (Status != RequestStatus.Draft && Status != RequestStatus.New)
        {
            throw new InvalidOperationException("Cannot update request customers when the status is not Draft or New.");
        }

        if (!_customers.SequenceEqual(customers))
        {
            _customers.Clear();
            _customers.AddRange(customers);
        }
    }

    public void UpdateProperties(List<RequestProperty> properties)
    {
        if (Status != RequestStatus.Draft && Status != RequestStatus.New)
        {
            throw new InvalidOperationException(
                "Cannot update request properties when the status is not Draft or New.");
        }

        if (!_properties.SequenceEqual(properties))
        {
            _properties.Clear();
            _properties.AddRange(properties);
        }
    }

    public void AddCustomer(string name, string contactNumber)
    {
        if (_customers.Any(c => c.Name == name))
        {
            throw new ArgumentException($"Customer with name '{name}' already exists.");
        }

        var customer = RequestCustomer.Create(name, contactNumber);

        _customers.Add(customer);
    }

    public void RemoveCustomer(string name)
    {
        var initialCount = _customers.Count;
        var customers = _customers.Where(c => c.Name != name).ToList();

        if (initialCount == customers.Count)
        {
            throw new ArgumentException($"Customer with name '{name}' does not exist.");
        }

        _customers.Clear();
        _customers.AddRange(customers);
    }

    public void AddProperty(string propertyType, string buildingType, decimal? sellingPrice)
    {
        if (_properties.Any(p => p.PropertyType == propertyType && p.BuildingType == buildingType))
        {
            throw new ArgumentException(
                $"Property with type '{propertyType}' and building type '{buildingType}' already exists.");
        }

        var property = RequestProperty.Of(propertyType, buildingType, sellingPrice);

        _properties.Add(property);
    }

    public void RemoveProperty(string propertyType, string buildingType)
    {
        var initialCount = _properties.Count;
        var properties = _properties.Where(c => c.PropertyType != propertyType && c.BuildingType != buildingType)
            .ToList();

        if (initialCount == properties.Count)
        {
            throw new ArgumentException(
                $"Property with type '{propertyType}' and building type '{buildingType}' does not exist.");
        }

        _properties.Clear();
        _properties.AddRange(properties);
    }

    public void AddComment(string comment)
    {
        _comments.Add(RequestComment.Create(comment));
    }

    public void UpdateComment(long commentId, string newComment)
    {
        var comment = _comments.FirstOrDefault(c => c.Id == commentId);
        if (comment == null)
        {
            throw new NotFoundException($"Comment with ID '{commentId}' does not exist.");
        }

        comment.Update(newComment);
    }

    public void RemoveComment(long commentId)
    {
        var comment = _comments.FirstOrDefault(c => c.Id == commentId);
        if (comment == null)
        {
            throw new NotFoundException($"Comment with ID '{commentId}' does not exist.");
        }

        _comments.Remove(comment);
    }
}