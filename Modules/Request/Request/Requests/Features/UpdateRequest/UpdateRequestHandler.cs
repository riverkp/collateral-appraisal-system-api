namespace Request.Requests.Features.UpdateRequest;

public record UpdateRequestCommand(long Id, RequestDetailDto Detail) : ICommand<UpdateRequestResult>;

public record UpdateRequestResult(bool IsSuccess);

internal class UpdateRequestHandler(RequestDbContext dbContext)
    : ICommandHandler<UpdateRequestCommand, UpdateRequestResult>
{
    public async Task<UpdateRequestResult> Handle(UpdateRequestCommand command, CancellationToken cancellationToken)
    {
        // Handle the request and return a result
        var request = await dbContext.Requests.FindAsync([command.Id], cancellationToken);
        if (request is null) throw new RequestNotFoundException(command.Id);

        var requestDetail = command.Detail.Adapt<RequestDetail>();
        request.UpdateDetail(requestDetail);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateRequestResult(true);
    }
}