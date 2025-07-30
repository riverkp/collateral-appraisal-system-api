using MassTransit;
using Notification.Notification.Dtos;
using Notification.Notification.Services;
using Shared.Messaging.Commands;

namespace Notification.Notification.CommandHandlers;

public class NotifyAssignmentCommandHandler(INotificationService notificationService) : IConsumer<NotifyAssignment>
{
    public async Task Consume(ConsumeContext<NotifyAssignment> context)
    {
        var notification = new TaskAssignedNotificationDto(
            context.Message.CorrelationId,
            context.Message.TaskName,
            context.Message.AssignedTo,
            context.Message.AssignedType,
            GetRequestIdFromContext(context),
            context.Message.TaskName.ToString(),
            DateTime.UtcNow,
            context.Message.NotifiedTo
        );
        await notificationService.SendTaskAssignedToOtherNotificationAsync(notification);
    }

    private static long GetRequestIdFromContext(ConsumeContext<NotifyAssignment> context)
    {
        if (context.Headers.TryGetHeader("RequestId", out var requestIdObj) && 
            long.TryParse(requestIdObj?.ToString(), out var requestId))
        {
            return requestId;
        }

        return 0;
    }
}