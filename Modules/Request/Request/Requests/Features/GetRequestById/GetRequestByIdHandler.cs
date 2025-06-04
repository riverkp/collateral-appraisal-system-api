using Request.Contracts.Requests.Dtos;
using Request.Contracts.Requests.Features.GetRequestById;

namespace Request.Requests.Features.GetRequestById;

// public record GetRequestByIdQuery(Guid Id) : IQuery<GetRequestByIdResult>;
// public record GetRequestByIdResult(RequestDto Request);

public class GetRequestByIdHandler(RequestDbContext dbContext) : IQueryHandler<GetRequestByIdQuery, GetRequestByIdResult>
{
    public async Task<GetRequestByIdResult> Handle(GetRequestByIdQuery query, CancellationToken cancellationToken)
    {
        var request = await dbContext.Requests.FindAsync([query.Id], cancellationToken);
        if (request is null)
        {
            throw new RequestNotFoundException(query.Id);
        }

        var response = request.Adapt<RequestDto>();

        return new GetRequestByIdResult(response);
    }
}
