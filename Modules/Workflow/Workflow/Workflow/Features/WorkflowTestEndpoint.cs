using Carter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Workflow.Services;

namespace Workflow.Workflow.Features;

public class WorkflowTestEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/workflow/kickstart-internal",
            async (IWorkflowService workflowService, CancellationToken cancellationToken) =>
            {
                await workflowService.StartWorkflowAsync(Guid.NewGuid());

                return Results.Ok("");
            });

        app.MapPost("/workflow/decision",
            async (DecisionRequest request, IWorkflowService workflowService, CancellationToken cancellationToken) =>
            {
                await workflowService.DecisionAsync(request.CorrelationId, request.ActivityName, request.ActionTaken);
                return Results.Ok("");
            });
    }
}

public class DecisionRequest
{
    public string CorrelationId { get; set; } = default!;
    public string ActivityName { get; set; } = default!;
    public string ActionTaken { get; set; } = default!;
}