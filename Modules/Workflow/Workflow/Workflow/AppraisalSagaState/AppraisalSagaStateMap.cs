namespace Workflow.Workflow.AppraisalSagaState;

public class AppraisalSagaStateMap : SagaClassMap<AppraisalSagaState>
{
    protected override void Configure(EntityTypeBuilder<AppraisalSagaState> entity, ModelBuilder model)
    {
        entity.Property(x => x.CurrentState);
        entity.Property(x => x.SubmittedBy);
        entity.Property(x => x.AssignedStaff);
        entity.Property(x => x.SubmittedAt);
        entity.Property(x => x.AssignedAt);
        entity.Property(x => x.CheckedBy);
        entity.Property(x => x.CheckedAt);
        entity.Property(x => x.VerifiedBy);
        entity.Property(x => x.VerifiedAt);
        entity.Property(x => x.CommitteeUserId);
        entity.Property(x => x.FinalDecision);
        entity.Property(x => x.DecidedAt);
    }
}