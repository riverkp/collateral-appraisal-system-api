namespace Request.Requests.ValueObjects;

public record Reference(
    string? PrevAppraisalNo,
    decimal? PrevAppraisalValue,
    DateTime? PrevAppraisalDate
);