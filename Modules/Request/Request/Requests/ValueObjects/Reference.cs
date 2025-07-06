namespace Request.Requests.ValueObjects;

public record Reference
{
    public string? PrevAppraisalNo { get; }
    public decimal? PrevAppraisalValue { get; }
    public DateTime? PrevAppraisalDate { get; }
        
    private Reference(string? prevAppraisalNo, decimal? prevAppraisalValue, DateTime? prevAppraisalDate)
    {
        PrevAppraisalNo = prevAppraisalNo;
        PrevAppraisalValue = prevAppraisalValue;
        PrevAppraisalDate = prevAppraisalDate;
    }
    
    public static Reference Create(string? prevAppraisalNo, decimal? prevAppraisalValue, DateTime? prevAppraisalDate)
    {
        return new Reference(prevAppraisalNo, prevAppraisalValue, prevAppraisalDate);
    }
    
    public virtual bool Equals(Reference? other)
    {
        if (ReferenceEquals(null, other)) return IsEmpty();
        if (ReferenceEquals(this, other)) return true;

        // Both empty = equal
        if (IsEmpty() && other.IsEmpty()) return true;

        return PrevAppraisalNo == other.PrevAppraisalNo &&
               PrevAppraisalValue == other.PrevAppraisalValue &&
               PrevAppraisalDate == other.PrevAppraisalDate;
    }

    public override int GetHashCode()
    {
        return IsEmpty() ? 0 : HashCode.Combine(PrevAppraisalNo, PrevAppraisalValue, PrevAppraisalDate);
    }

    private bool IsEmpty() =>
        PrevAppraisalNo is null &&
        PrevAppraisalValue is null &&
        PrevAppraisalDate is null;
}