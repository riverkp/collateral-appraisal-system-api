namespace Request.Requests.ValueObjects;

public record RequestDetail
{
    public string Purpose { get; } = default!;
    public bool HasAppraisalBook { get; }
    public string Priority { get; } = default!;
    public string Channel { get; } = default!;
    public int? OccurConstInspec { get; }
    public LoanDetail LoanDetail { get; } = default!;
    public Reference Reference { get; } = default!;
    public Address Address { get; } = default!;
    public Contact Contact { get; } = default!;
    public Fee Fee { get; } = default!;
    public Requestor Requestor { get; } = default!;

    private RequestDetail()
    {
        // For EF Core
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("SonarQube", "S107:Methods should not have too many parameters")]
    private RequestDetail(
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
        Purpose = purpose;
        HasAppraisalBook = hasAppraisalBook;
        Priority = priority;
        Channel = channel;
        OccurConstInspec = occurConstInspec;
        Reference = reference;
        LoanDetail = loanDetail;
        Address = address;
        Contact = contact;
        Fee = fee;
        Requestor = requestor;
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("SonarQube", "S107:Methods should not have too many parameters")]
    public static RequestDetail Create(
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
        ArgumentNullException.ThrowIfNull(purpose);
        ArgumentNullException.ThrowIfNull(priority);
        ArgumentNullException.ThrowIfNull(channel);
        ArgumentNullException.ThrowIfNull(address);
        ArgumentNullException.ThrowIfNull(contact);
        ArgumentNullException.ThrowIfNull(fee);
        ArgumentNullException.ThrowIfNull(requestor);

        return new RequestDetail(
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
            requestor);
    }

    public virtual bool Equals(RequestDetail? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return Purpose == other.Purpose &&
               HasAppraisalBook == other.HasAppraisalBook &&
               Priority == other.Priority &&
               Channel == other.Channel &&
               OccurConstInspec == other.OccurConstInspec &&
               LoanDetail.Equals(other.LoanDetail) &&
               Reference.Equals(other.Reference) &&
               Address.Equals(other.Address) &&
               Contact.Equals(other.Contact) &&
               Fee.Equals(other.Fee) &&
               Requestor.Equals(other.Requestor);
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(Purpose);
        hash.Add(HasAppraisalBook);
        hash.Add(Priority);
        hash.Add(Channel);
        hash.Add(OccurConstInspec);
        hash.Add(Reference);
        hash.Add(LoanDetail);
        hash.Add(Address);
        hash.Add(Contact);
        hash.Add(Fee);
        hash.Add(Requestor);
        return hash.ToHashCode();
    }
}