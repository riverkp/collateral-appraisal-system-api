namespace Request.Requests.ValueObjects;

public record Fee(
    string FeeType,
    string? FeeRemark
);