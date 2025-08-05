using Shared.Messaging.Values;

namespace Notification.Notification.Dtos;

public record TaskAssignedNotificationDto(
    Guid CorrelationId,
    TaskName TaskName,
    string AssignedTo,
    string AssignedType,
    long RequestId,
    string CurrentState,
    DateTime AssignedAt,
    string? NotifiedTo = default!
);