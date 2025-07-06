namespace Request.Requests.ValueObjects;

public record LoanDetail
{
    public string? LoanApplicationNo { get; }
    public decimal? LimitAmt { get; }
    public decimal? TotalSellingPrice { get; }

    private LoanDetail(string? loanApplicationNo, decimal? limitAmt, decimal? totalSellingPrice)
    {
        LoanApplicationNo = loanApplicationNo;
        LimitAmt = limitAmt;
        TotalSellingPrice = totalSellingPrice;
    }

    public static LoanDetail Create(string? loanApplicationNo, decimal? limitAmt, decimal? totalSellingPrice)
    {
        return new LoanDetail(loanApplicationNo, limitAmt, totalSellingPrice);
    }

    public virtual bool Equals(LoanDetail? other)
    {
        if (ReferenceEquals(null, other)) return IsEmpty();
        if (ReferenceEquals(this, other)) return true;

        // Both empty = equal
        if (IsEmpty() && other.IsEmpty()) return true;

        return LoanApplicationNo == other.LoanApplicationNo &&
               LimitAmt == other.LimitAmt &&
               TotalSellingPrice == other.TotalSellingPrice;
    }

    public override int GetHashCode()
    {
        return IsEmpty() ? 0 : HashCode.Combine(LoanApplicationNo, LimitAmt, TotalSellingPrice);
    }

    private bool IsEmpty() =>
        LoanApplicationNo is null &&
        LimitAmt is null &&
        TotalSellingPrice is null;
}