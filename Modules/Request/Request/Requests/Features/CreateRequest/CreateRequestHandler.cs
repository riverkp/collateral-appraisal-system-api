namespace Request.Requests.Features.CreateRequest;

public record CreateRequestCommand(RequestDetailDto Detail) : ICommand<CreateRequestResult>;

public record CreateRequestResult(long Id);

public class CreateRequestCommandValidator : AbstractValidator<CreateRequestCommand>
{
    public CreateRequestCommandValidator()
    {
        RuleFor(x => x.Detail.Purpose).NotEmpty().WithMessage("Purpose is required.");
        RuleFor(x => x.Detail.Channel).NotEmpty().WithMessage("Channel is required.");
    }
}

internal class CreateRequestHandler(RequestDbContext dbContext)
    : ICommandHandler<CreateRequestCommand, CreateRequestResult>
{
    public async Task<CreateRequestResult> Handle(CreateRequestCommand command, CancellationToken cancellationToken)
    {
        var request = CreateNewRequest(command.Detail);
        dbContext.Requests.Add(request);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateRequestResult(request.Id);
    }

    private static Models.Request CreateNewRequest(RequestDetailDto detail)
    {
        var requestDetail = detail.Adapt<RequestDetail>();
        return Models.Request.From(requestDetail);
    }
}