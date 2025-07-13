using System.ComponentModel;
using Elsa.Extensions;
using Elsa.Workflows.Activities.Flowchart.Activities;
using Elsa.Workflows.Activities.Flowchart.Models;
using Workflow.Workflow.Activities;
using Workflow.Workflow.Extensions;
using Endpoint = Elsa.Workflows.Activities.Flowchart.Models.Endpoint;
using Event = Elsa.Workflows.Runtime.Activities.Event;

namespace Workflow.Workflow.AppraisalWorkflow;

[DisplayName("Internal Appraisal Workflow")]
[Description("A workflow for handling internal property appraisals with routing and branching.")]
public class InternalAppraisalWorkflow : WorkflowBase
{
    protected override void Build(IWorkflowBuilder builder)
    {
        var correlationId = builder.WithVariable<string>();
        var payload = builder.WithVariable<object>();

        // Define all activities first
        var start = new Event("KickstartWorkflow")
        {
            Id = "KickstartWorkflow",
            Name = "KickstartWorkflow",
            CanStartWorkflow = true,
            Result = new(payload)
        };
        var end = new Finish();

        var requestMaker = new UserTask
        {
            Id = "RequestMaker",
            TaskName = new("RequestMaker"),
            AssignedTo = new(context => payload.Get(context)!.ConvertTo<UserResponse>().AssignTo),
            AssignedType = new(context => payload.Get(context)!.ConvertTo<UserResponse>().AssignType),
        };
        var admin = new UserTask
        {
            Id = "Admin",
            TaskName = new("Admin"),
            AssignedTo = new(context => payload.Get(context)!.ConvertTo<UserResponse>().AssignTo),
            AssignedType = new(context => payload.Get(context)!.ConvertTo<UserResponse>().AssignType),
        };
        var appraisalStaff = new UserTask
        {
            Id = "AppraisalStaff",
            TaskName = new("AppraisalStaff"),
            AssignedTo = new(context => payload.Get(context)!.ConvertTo<UserResponse>().AssignTo),
            AssignedType = new(context => payload.Get(context)!.ConvertTo<UserResponse>().AssignType),
        };
        var appraisalChecker = new UserTask
        {
            Id = "AppraisalChecker",
            TaskName = new("AppraisalChecker"),
            AssignedTo = new(context => payload.Get(context)!.ConvertTo<UserResponse>().AssignTo),
            AssignedType = new(context => payload.Get(context)!.ConvertTo<UserResponse>().AssignType),
        };
        var appraisalVerifier = new UserTask
        {
            Id = "AppraisalVerifier",
            TaskName = new("AppraisalVerifier"),
            AssignedTo = new(context => payload.Get(context)!.ConvertTo<UserResponse>().AssignTo),
            AssignedType = new(context => payload.Get(context)!.ConvertTo<UserResponse>().AssignType),
        };

        var requestMakerAction = new FlowDecision(context => context.GetInput<string>("ActionTaken") == "P");
        var adminAction = new FlowDecision(context => context.GetInput<string>("ActionTaken") == "P");
        var appraisalStaffAction = new FlowDecision(context => context.GetInput<string>("ActionTaken") == "P");
        var appraisalCheckerAction = new FlowDecision(context => context.GetInput<string>("ActionTaken") == "P");
        var appraisalVerifierAction = new FlowDecision(context => context.GetInput<string>("ActionTaken") == "P");

        // Build the flowchart
        builder.Root = new Flowchart
        {
            Activities =
            {
                start,
                requestMaker,
                admin,
                appraisalStaff,
                appraisalChecker,
                appraisalVerifier,
                end,

                requestMakerAction,
                adminAction,
                appraisalStaffAction,
                appraisalCheckerAction,
                appraisalVerifierAction
            },

            Connections =
            {
                // 🎯 Start Flow
                new(start, admin),

                new(admin, adminAction),
                new(new Endpoint(adminAction, "True"), new Endpoint(appraisalStaff)),
                new(new Endpoint(adminAction, "False"), new Endpoint(requestMaker)),

                new(appraisalStaff, appraisalStaffAction),
                new(new Endpoint(appraisalStaffAction, "True"), new Endpoint(appraisalChecker)),
                new(new Endpoint(appraisalStaffAction, "False"), new Endpoint(admin)),

                new(appraisalChecker, appraisalCheckerAction),
                new(new Endpoint(appraisalCheckerAction, "True"), new Endpoint(appraisalVerifier)),
                new(new Endpoint(appraisalCheckerAction, "False"), new Endpoint(appraisalStaff)),

                new(appraisalVerifier, appraisalVerifierAction),
                new(new Endpoint(appraisalVerifierAction, "True"), new Endpoint(end)),
                new(new Endpoint(appraisalVerifierAction, "False"), new Endpoint(appraisalChecker)),

                new(requestMaker, requestMakerAction),
                new(new Endpoint(requestMakerAction, "True"), new Endpoint(admin)),
                new(new Endpoint(requestMakerAction, "False"), new Endpoint(end)),
            }
        };
    }
}

public class UserResponse
{
    public string RequestId { get; set; } = default!;
    public string AssignTo { get; set; } = default!;
    public string AssignType { get; set; } = default!;
}