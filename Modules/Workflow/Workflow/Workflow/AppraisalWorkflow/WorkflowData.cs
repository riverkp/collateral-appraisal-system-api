namespace Workflow.Workflow.AppraisalWorkflow;

public class WorkflowData
{
    public string RequestId { get; set; } = string.Empty;
    public string SubmittedBy { get; set; } = string.Empty;
    public DateTime SubmittedAt { get; set; }
    public string Status { get; set; } = string.Empty;
    public string AssignedStaff { get; set; } = string.Empty;
    public string CheckerId { get; set; } = string.Empty;
    public string VerifierId { get; set; } = string.Empty;
    public List<string> CommitteeMembers { get; set; } = new();
    public decimal PropertyValue { get; set; }
    public string RiskLevel { get; set; } = string.Empty;
    public string Comments { get; set; } = string.Empty;
    public string PropertyAddress { get; set; } = string.Empty;
}