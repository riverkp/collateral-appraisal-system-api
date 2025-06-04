namespace Request.Contracts.Requests.Dtos;

public record RequestDto
(
    Guid Id,
    string Purpose,
    string Channel
);
