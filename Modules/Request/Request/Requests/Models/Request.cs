namespace Request.Requests.Models;

public class Request : Aggregate<Guid>
{
    public string Purpose { get; private set; } = default!;
    public string Channel { get; private set; } = default!;
    private readonly List<RequestCustomer> _customers = new();
    public IReadOnlyList<RequestCustomer> Customers => _customers.AsReadOnly();

    public Request(Guid id, string purpose, string channel)
    {
        Id = id;
        Purpose = purpose;
        Channel = channel;

        AddDomainEvent(new RequestCreatedEvent(this));
    }

    public void Update(string purpose, string channel)
    {
        ArgumentException.ThrowIfNullOrEmpty(purpose);
        ArgumentException.ThrowIfNullOrEmpty(channel);

        Purpose = purpose;
        Channel = channel;
    }

    // TODO: Add domain events
    // TODO: Add AddCustomer/RemoveCustomer methods
}
