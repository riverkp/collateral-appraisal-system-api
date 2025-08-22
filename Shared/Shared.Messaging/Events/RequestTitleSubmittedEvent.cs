using Shared.Dtos;

namespace Shared.Messaging.Events;

public record RequestTitleSubmittedEvent : IntegrationEvent
{
    public long RequestId { get; set; } = default!;
    public List<RequestTitleDto> RequestTitles { get; set; } = default!;
}