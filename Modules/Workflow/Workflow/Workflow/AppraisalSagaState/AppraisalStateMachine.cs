// using Workflow.Workflow.Events;
//
// namespace Workflow.Workflow.AppraisalSagaState;
//
// public class AppraisalStateMachine : MassTransitStateMachine<AppraisalSagaState>
// {
//     public State Submitted { get; private set; } = default!;
//     public State StaffAssignedState { get; private set; } = default!;
//     public State Checked { get; private set; } = default!;
//     public State Verified { get; private set; } = default!;
//     public State Finalized { get; private set; } = default!;
//
//     public Event<AppraisalSubmitted> AppraisalSubmitted { get; private set; } = default!;
//     public Event<StaffAssigned> StaffAssigned { get; private set; } = default!;
//     public Event<StaffChecked> StaffChecked { get; private set; } = default!;
//     public Event<VerifiedByChecker> VerifiedByChecker { get; private set; } = default!;
//     public Event<CommitteeDecision> CommitteeDecision { get; private set; } = default!;
//
//     public AppraisalStateMachine()
//     {
//         InstanceState(x => x.CurrentState);
//
//         Event(() => AppraisalSubmitted, x => x.CorrelateById(m => m.Message.RequestId));
//         Event(() => StaffAssigned, x => x.CorrelateById(m => m.Message.RequestId));
//         Event(() => StaffChecked, x => x.CorrelateById(m => m.Message.RequestId));
//         Event(() => VerifiedByChecker, x => x.CorrelateById(m => m.Message.RequestId));
//         Event(() => CommitteeDecision, x => x.CorrelateById(m => m.Message.RequestId));
//
//         Initially(
//             When(AppraisalSubmitted)
//                 .Then(ctx =>
//                 {
//                     ctx.Saga.SubmittedBy = ctx.Message.SubmittedBy;
//                     ctx.Saga.SubmittedAt = ctx.Message.SubmittedAt;
//                 })
//                 .TransitionTo(Submitted)
//         );
//
//         During(Submitted,
//             When(StaffAssigned)
//                 .Then(ctx =>
//                 {
//                     ctx.Saga.AssignedStaff = ctx.Message.StaffId;
//                     ctx.Saga.AssignedAt = ctx.Message.AssignedAt;
//                 })
//                 .TransitionTo(StaffAssignedState)
//         );
//
//         During(StaffAssignedState,
//             When(StaffChecked)
//                 .Then(ctx =>
//                 {
//                     ctx.Saga.CheckedBy = ctx.Message.StaffId;
//                     ctx.Saga.CheckedAt = ctx.Message.CheckedAt;
//                 })
//                 .TransitionTo(Checked)
//         );
//
//         During(Checked,
//             When(VerifiedByChecker)
//                 .Then(ctx =>
//                 {
//                     ctx.Saga.VerifiedBy = ctx.Message.CheckerId;
//                     ctx.Saga.VerifiedAt = ctx.Message.VerifiedAt;
//                 })
//                 .TransitionTo(Verified)
//         );
//
//         During(Verified,
//             When(CommitteeDecision)
//                 .Then(ctx =>
//                 {
//                     ctx.Saga.CommitteeUserId = ctx.Message.CommitteeUserId;
//                     ctx.Saga.DecidedAt = ctx.Message.DecidedAt;
//                     ctx.Saga.FinalDecision = ctx.Message.Decision.ToString();
//                 })
//                 .TransitionTo(Finalized)
//         );
//     }
// }

