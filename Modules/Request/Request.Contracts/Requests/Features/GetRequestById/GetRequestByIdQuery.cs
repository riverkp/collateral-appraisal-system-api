using Shared.Contracts.CQRS;

namespace Request.Contracts.Requests.Features.GetRequestById;

public record GetRequestByIdQuery(long Id) : IQuery<GetRequestByIdResult>;

public record GetRequestByIdResult(RequestDto Request);