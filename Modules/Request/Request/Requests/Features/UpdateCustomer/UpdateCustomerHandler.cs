namespace Request.Requests.Features.UpdateCustomer;

public record UpdateCustomerCommand(long Id, List<RequestCustomerDto> Customers) : ICommand<UpdateCustomerResult>;

public record UpdateCustomerResult(bool IsSuccess);

internal class UpdateCustomerHandler(RequestDbContext dbContext) : ICommandHandler<UpdateCustomerCommand, UpdateCustomerResult>
{
    public async Task<UpdateCustomerResult> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
    {
        var request = await dbContext.Requests.FindAsync([command.Id], cancellationToken) ?? throw new RequestNotFoundException(command.Id);
        var customers = command.Customers.Adapt<List<RequestCustomer>>();

        request.ClearCustomer();
        foreach (var customer in customers)
        {
            request.AddCustomer(customer);
        }
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateCustomerResult(true);
    }
}

