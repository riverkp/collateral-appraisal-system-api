namespace Request.Requests.Features.UpdateRequest;

public record UpdateRequestCommand(RequestDto Request) : ICommand<UpdateRequestResult>;
public record UpdateRequestResult(bool IsSuccess);
internal class UpdateRequestHandler(RequestDbContext dbContext) : ICommandHandler<UpdateRequestCommand, UpdateRequestResult>
{
    public async Task<UpdateRequestResult> Handle(UpdateRequestCommand command, CancellationToken cancellationToken)
    {
        // Handle the request and return a result
        var request = await dbContext.Requests.FindAsync([command.Request.Id], cancellationToken);
        if (request is null)
        {
            throw new RequestNotFoundException(command.Request.Id);
        }

        request.Update(command.Request.Purpose, command.Request.Channel);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateRequestResult(true);
    }
}
