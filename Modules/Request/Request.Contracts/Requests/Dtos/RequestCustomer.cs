namespace Request.Requests.ValueObjects;

public record RequestCustomer
{
    public RequestCustomer()
    {
    }

    private RequestCustomer(
        string custName,
        string contactNo
    )
    {
        CustName = custName;
        ContactNo = contactNo;
    }
    public string CustName { get; }
    public string ContactNo { get; }

    public static RequestCustomer Of(
        string custName,
        string contactNo
    )
    {
        ArgumentException.ThrowIfNullOrEmpty(custName);
        ArgumentException.ThrowIfNullOrEmpty(contactNo);

        return new RequestCustomer(
            custName,
            contactNo
        );
    }
} 