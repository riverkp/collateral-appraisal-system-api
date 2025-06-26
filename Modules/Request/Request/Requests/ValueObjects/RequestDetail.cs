namespace Request.Requests.ValueObjects;

public record RequestDetail
{
    public RequestDetail()
    {
    }

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

    public string Purpose { get; }
    public bool HasAppraisalBook { get; }
    public string Priority { get; }
    public string Channel { get; }
    public int? OccurConstInspec { get; }
    public LoanDetail LoanDetail { get; }
    public Reference Reference { get; }
    public Address Address { get; }
    public Contact Contact { get; }
    public Fee Fee { get; }
    public Requestor Requestor { get; }

    public static RequestDetail Of(
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
}