using Microsoft.VisualBasic;
using Shared.Messaging.Events;
using StackExchange.Redis;

namespace Assignment.Sagas.AppraisalSaga;

public partial class AppraisalStateMachine : MassTransitStateMachine<AppraisalSagaState>
{
    // Service
    private readonly IDateTimeProvider _dateTimeProvider;

    // States representing workflow activities
    public State RequestMakerAwaitingAssignment { get; private set; } = default!;
    public State AdminAwaitingAssignment { get; private set; } = default!;
    public State AppraisalStaffAwaitingAssignment { get; private set; } = default!;
    public State AppraisalCheckerAwaitingAssignment { get; private set; } = default!;
    public State AppraisalVerifierAwaitingAssignment { get; private set; } = default!;
    public State AppraisalCommitteeAwaitingAssignment { get; private set; } = default!;
    public State RequestMaker { get; private set; } = default!;
    public State RequestChecker { get; private set; } = default!;
    public State Admin { get; private set; } = default!;
    public State AppraisalStaff { get; private set; } = default!;
    public State AppraisalChecker { get; private set; } = default!;
    public State AppraisalVerifier { get; private set; } = default!;
    public State AppraisalCommittee { get; private set; } = default!;

    // Events for workflow activities
    public Event<RequestSubmitted> RequestSubmitted { get; private set; } = default!;
    public Event<TaskCompleted> TaskCompleted { get; private set; } = default!;
    public Event<TaskAssigned> TaskAssigned { get; private set; } = default!;
    public AppraisalStateMachine(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;

        InstanceState(x => x.CurrentState);

        // Event(() => RequestSubmitted, x => x.CorrelateById(m => m.Message.CorrelationId));
        // Event(() => TaskCompleted, x => x.CorrelateById(m => m.Message.CorrelationId));
        Event(() => TaskAssigned, x => x.CorrelateById(m => m.Message.CorrelationId));

        Initially(
            When(RequestSubmitted)
                .Then(Initialize)
                .TransitionTo(AdminAwaitingAssignment)
                .Then(AssignmentRequest)
        );

        AwaitingAssignment(AdminAwaitingAssignment, "Admin");
        DuringProcess(Admin, AppraisalStaff, RequestMaker, "Admin");


        // During(AdminAwaitingAssignment,
        //     When(TaskAssigned)
        //         .TransitionTo(Admin)
        //         .Then(TransitionCompleted)
        // );

        // During(AppraisalStaffAwaitingAssignment,
        //     When(TaskAssigned)
        //         .TransitionTo(Admin)
        //         .Then(TransitionCompleted)
        // );


        // // Admin
        // During(Admin,
        //     When(TaskAssigned)
        //         .If(context => context.Message.TaskName == "Admin", then => then
        //             .Then(TransitionCompleted)
        //         ),
        //     When(TaskCompleted)
        //         .If(context => context.Message.TaskName == "Admin", then => then
        //             .Then(CompleteActivity)
        //             .If(context => context.Message.ActionTaken == "P", proceed => proceed
        //                 .TransitionTo(AppraisalStaff)
        //                 .Then(AssignmentRequest)
        //             )
        //             .If(context => context.Message.ActionTaken == "R", routeBack => routeBack
        //                 .TransitionTo(RequestMaker)
        //                 .Then(AssignmentRequest)
        //             )
        //         )
        // );

        // // Appraisal Staff
        // During(AppraisalStaff,
        //     When(TaskAssigned)
        //         .If(context => context.Message.TaskName == "AppraisalStaff", then => then
        //             .Then(TransitionCompleted)
        //         ),
        //     When(TaskCompleted)
        //         .If(context => context.Message.TaskName == "AppraisalStaff", then => then
        //             .Then(CompleteActivity)
        //             .If(context => context.Message.ActionTaken == "P", proceed => proceed
        //                 .TransitionTo(AppraisalChecker)
        //                 .Then(AssignmentRequest)
        //             )
        //             .If(context => context.Message.ActionTaken == "R", routeBack => routeBack
        //                 .TransitionTo(Admin)
        //                 .Then(AssignmentRequest)
        //             )
        //         )
        // );

        // // Appraisal Checker
        // During(AppraisalChecker,
        //     When(TaskAssigned)
        //         .If(context => context.Message.TaskName == "AppraisalChecker", then => then
        //             .Then(TransitionCompleted)
        //         ),
        //     When(TaskCompleted)
        //         .If(context => context.Message.TaskName == "AppraisalChecker", then => then
        //             .Then(CompleteActivity)
        //             .If(context => context.Message.ActionTaken == "P", proceed => proceed
        //                 .TransitionTo(AppraisalVerifier)
        //                 .Then(AssignmentRequest)
        //             )
        //             .If(context => context.Message.ActionTaken == "R", routeBack => routeBack
        //                 .TransitionTo(AppraisalStaff)
        //                 .Then(AssignmentRequest)
        //             )
        //         )
        // );

        // // Appraisal Verifier
        // During(AppraisalVerifier,
        //     When(TaskAssigned)
        //         .If(context => context.Message.TaskName == "AppraisalVerifier", then => then
        //             .Then(TransitionCompleted)
        //         ),
        //     When(TaskCompleted)
        //         .If(context => context.Message.TaskName == "AppraisalVerifier", then => then
        //             .Then(CompleteActivity)
        //             .If(context => context.Message.ActionTaken == "P", proceed => proceed
        //                 .Finalize()
        //             )
        //             .If(context => context.Message.ActionTaken == "R", routeBack => routeBack
        //                 .TransitionTo(AppraisalChecker)
        //                 .Then(AssignmentRequest)
        //             )
        //         )
        // );

        SetCompletedWhenFinalized();
    }
    private void AwaitingAssignment(State state, string taskName)
    {
        During(state,
            When(TaskAssigned)
                .If(context => context.Message.TaskName == taskName, then => then
                    .Then(TransitionCompleted))
        );
    }

    private void DuringProcess(State currState, State nextState, State routeBackState,string taskName)
    {
        During(currState,
            When(TaskCompleted)
                .If(context => context.Message.TaskName == taskName, then => then
                    .Then(CompleteActivity)
                    .If(context => context.Message.ActionTaken == "P", proceed => proceed
                        .TransitionTo(nextState)
                        .Then(AssignmentRequest)
                    )
                    .If(context => context.Message.ActionTaken == "R", routeBack => routeBack
                        .TransitionTo(routeBackState)
                        .Then(AssignmentRequest)
                    ))
        );
    }
}