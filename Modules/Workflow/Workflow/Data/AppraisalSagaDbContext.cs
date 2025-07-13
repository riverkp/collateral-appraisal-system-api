using MassTransit.EntityFrameworkCoreIntegration;
using Workflow.Workflow.AppraisalSagaState;

namespace Workflow.Data;

public class AppraisalSagaDbContext : SagaDbContext
{
    public AppraisalSagaDbContext(DbContextOptions<AppraisalSagaDbContext> options) : base(options)
    {
    }

    protected override IEnumerable<ISagaClassMap> Configurations =>
        new ISagaClassMap[] { new AppraisalSagaStateMap() };
}