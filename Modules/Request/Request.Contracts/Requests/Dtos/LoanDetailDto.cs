namespace Request.Contracts.Requests.Dtos;

public record LoanDetailDto(
    string? LoanApplicationNo,
    decimal? LimitAmt,
    decimal? TotalSellingPrice
);