namespace Workflow.Services;

public interface IWorkflowService
{
    Task StartWorkflowAsync(Guid requestId);
    Task DecisionAsync(string correlationId, string activityName, string actiontaken);
}