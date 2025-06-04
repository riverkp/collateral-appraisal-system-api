namespace Shared.Messaging.Events;

public record RequestCreatedIntegrationEvent : IntegrationEvent
{
    public Guid RequestId { get; set; } = Guid.Empty;
    public string Purpose { get; set; } = default!;
    public string Channel { get; set; } = default!;
}