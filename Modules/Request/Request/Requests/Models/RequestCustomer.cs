namespace Request.Requests.Models;

public class RequestCustomer : Entity<long>
{
    public RequestCustomer(string name, string contactNumber)
    {
        Name = name;
        ContactNumber = contactNumber;
    }

    [JsonConstructor]
    public RequestCustomer(long id, string name, string contactNumber)
    {
        Id = id;
        Name = name;
        ContactNumber = contactNumber;
    }

    public long RequestId { get; private set; }
    public string Name { get; private set; }
    public string ContactNumber { get; private set; }

    public void Update(string name, string contactNumber)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(contactNumber);

        Name = name;
        ContactNumber = contactNumber;
    }
}