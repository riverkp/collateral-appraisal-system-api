using System.Text.Json.Serialization;

namespace Request.Requests.Models;

public class RequestCustomer : Entity<Guid>
{
    public string Name { get; private set; } = default!;
    public string Email { get; private set; } = default!;

    public RequestCustomer(string name, string email)
    {
        Name = name;
        Email = email;
    }

    [JsonConstructor]
    public RequestCustomer(Guid id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }

    public void Update(string name, string email)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(email);

        Name = name;
        Email = email;
    }
}
