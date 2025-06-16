namespace Request.Contracts.Requests.Dtos;

public record RequestDetailDto(
    string Purpose,
    bool HasAppraisalBook,
    string Priority,
    ReferenceDto Reference,
    string Channel,
    string? LoanApplicationNo,
    decimal? LimitAmt,
    int? OccurConstInspec,
    decimal? TotalSellingPrice,
    AddressDto Address,
    ContactDto Contact,
    FeeDto Fee,
    RequestorDto Requestor
);