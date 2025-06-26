namespace Request.Requests.ValueObjects;

public record LoanDetail(string? LoanApplicationNo, decimal? LimitAmt, decimal? TotalSellingPrice);