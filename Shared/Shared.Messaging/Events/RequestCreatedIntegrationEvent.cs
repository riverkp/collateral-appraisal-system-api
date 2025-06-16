namespace Shared.Messaging.Events;

public record RequestCreatedIntegrationEvent : IntegrationEvent
{
    public long RequestId { get; set; } = default!;
    public string Purpose { get; set; } = default!;
    public string Channel { get; set; } = default!;
}