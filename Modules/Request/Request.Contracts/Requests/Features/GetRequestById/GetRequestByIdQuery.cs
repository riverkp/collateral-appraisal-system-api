using Shared.Contracts.CQRS;

namespace Request.Contracts.Requests.Features.GetRequestById;

public record GetRequestByIdQuery(Guid Id) : IQuery<GetRequestByIdResult>;
public record GetRequestByIdResult(RequestDto Request);
