namespace Request.Requests.ValueObjects;

public record RequestCustomer
{
    public RequestCustomer()
    {
    }

    private RequestCustomer(
        string name,
        string contactNumber
    )
    {
        Name = name;
        ContactNumber = contactNumber;
    }

    public string Name { get; }
    public string ContactNumber { get; }

    public static RequestCustomer Create(
        string name,
        string contactNumber
    )
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(contactNumber);

        return new RequestCustomer(
            name,
            contactNumber
        );
    }
}