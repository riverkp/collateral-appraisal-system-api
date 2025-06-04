namespace Request.Requests.Features.DeleteRequest;

public record DeleteRequestCommand(Guid RequestId) : ICommand<DeleteRequestResult>;
public record DeleteRequestResult(bool IsSuccess);
internal class DeleteRequestHandler(RequestDbContext dbContext) : ICommandHandler<DeleteRequestCommand, DeleteRequestResult>
{
    public async Task<DeleteRequestResult> Handle(DeleteRequestCommand command, CancellationToken cancellationToken)
    {
        var request = await dbContext.Requests.FindAsync([command.RequestId], cancellationToken);
        if (request is null)
        {
            throw new RequestNotFoundException(command.RequestId);
        }

        dbContext.Requests.Remove(request);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteRequestResult(true);
    }
}
