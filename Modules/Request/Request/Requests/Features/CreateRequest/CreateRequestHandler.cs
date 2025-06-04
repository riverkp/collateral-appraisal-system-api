namespace Request.Requests.Features.CreateRequest;

public record CreateRequestCommand(RequestDto Request) : ICommand<CreateRequestResult>;
public record CreateRequestResult(Guid Id);
public class CreateRequestCommandValidator : AbstractValidator<CreateRequestCommand>
{
    public CreateRequestCommandValidator()
    {
        RuleFor(x => x.Request.Purpose).NotEmpty().WithMessage("Purpose is required.");
        RuleFor(x => x.Request.Channel).NotEmpty().WithMessage("Channel is required.");
    }
}
internal class CreateRequestHandler(RequestDbContext dbContext) : ICommandHandler<CreateRequestCommand, CreateRequestResult>
{
    public async Task<CreateRequestResult> Handle(CreateRequestCommand command, CancellationToken cancellationToken)
    {
        // Handle the request and return a result
        var request = CreateNewRequest(command.Request);
        dbContext.Requests.Add(request);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateRequestResult(request.Id);
    }

    private Models.Request CreateNewRequest(RequestDto request)
    {
        return new Models.Request(Guid.NewGuid(), request.Purpose, request.Channel);
    }
}