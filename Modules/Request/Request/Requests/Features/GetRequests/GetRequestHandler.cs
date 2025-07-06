namespace Request.Requests.Features.GetRequests;

public class GetRequestHandler(RequestDbContext dbContext) : IQueryHandler<GetRequestQuery, GetRequestResult>
{
    public async Task<GetRequestResult> Handle(GetRequestQuery query, CancellationToken cancellationToken)
    {
        var requests = await dbContext.Requests.ToListAsync(cancellationToken);

        var result = requests.Adapt<List<RequestDto>>();

        return new GetRequestResult(result);
    }
}