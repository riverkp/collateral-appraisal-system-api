namespace Request.Requests.Features.DeleteRequest;

public record DeleteRequestCommand(long Id) : ICommand<DeleteRequestResult>;

public record DeleteRequestResult(bool IsSuccess);

internal class DeleteRequestHandler(RequestDbContext dbContext)
    : ICommandHandler<DeleteRequestCommand, DeleteRequestResult>
{
    public async Task<DeleteRequestResult> Handle(DeleteRequestCommand command, CancellationToken cancellationToken)
    {
        var request = await dbContext.Requests.FindAsync([command.Id], cancellationToken);
        if (request is null) throw new RequestNotFoundException(command.Id);

        dbContext.Requests.Remove(request);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteRequestResult(true);
    }
}