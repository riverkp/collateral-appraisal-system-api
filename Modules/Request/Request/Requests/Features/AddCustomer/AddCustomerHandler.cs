namespace Request.Requests.Features.AddCustomer;

public record AddCustomerCommand(long Id, List<RequestCustomerDto> Customers) : ICommand<AddCustomerResult>;

public record AddCustomerResult(bool IsSuccess);

internal class AddCustomerHandler(RequestDbContext dbContext) : ICommandHandler<AddCustomerCommand, AddCustomerResult>
{
    public async Task<AddCustomerResult> Handle(AddCustomerCommand command, CancellationToken cancellationToken)
    {
        var request = await dbContext.Requests.FindAsync([command.Id], cancellationToken) ?? throw new RequestNotFoundException(command.Id);
        var customers = command.Customers.Select(c => CreateNewCustomer(c));

        foreach (var customer in customers)
        {
            request.AddCustomer(customer);
        }
        await dbContext.SaveChangesAsync(cancellationToken);

        return new AddCustomerResult(true);
    }

    private static RequestCustomer CreateNewCustomer(RequestCustomerDto customer)
    {
        return RequestCustomer.Create(customer.Name, customer.ContactNumber);
    }
}