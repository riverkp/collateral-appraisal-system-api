namespace Shared.Messaging.Events;

public record RequestSubmittedIntegrationEvent : IntegrationEvent
{
    public long RequestId { get; set; } = default!;
}