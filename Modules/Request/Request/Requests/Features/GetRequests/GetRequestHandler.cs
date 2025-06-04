namespace Request.Requests.Features.GetRequests;

public record GetRequestQuery() : IQuery<GetRequestResult>;
public record GetRequestResult(List<RequestDto> Requests);
public class GetRequestHandler(RequestDbContext dbContext) : IQueryHandler<GetRequestQuery, GetRequestResult>
{
    public async Task<GetRequestResult> Handle(GetRequestQuery query, CancellationToken cancellationToken)
    {
        var requests = await dbContext.Requests.ToListAsync(cancellationToken);
        var response = requests.Adapt<List<RequestDto>>();
        return new GetRequestResult(response);
    }
}