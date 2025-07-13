namespace Workflow.Workflow.AppraisalSagaState;

public class AppraisalSagaState : SagaStateMachineInstance
{
    public Guid CorrelationId { get; set; }
    public string CurrentState { get; set; } = default!;

    public string? SubmittedBy { get; set; }
    public string? AssignedStaff { get; set; }
    public string? CheckedBy { get; set; }
    public string? VerifiedBy { get; set; }
    public string? CommitteeUserId { get; set; }
    public string? FinalDecision { get; set; }

    public DateTime? SubmittedAt { get; set; }
    public DateTime? AssignedAt { get; set; }
    public DateTime? CheckedAt { get; set; }
    public DateTime? VerifiedAt { get; set; }
    public DateTime? DecidedAt { get; set; }
}