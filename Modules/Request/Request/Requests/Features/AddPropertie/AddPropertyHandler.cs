namespace Request.Requests.Features.AddProperty;

public record AddPropertyCommand(long Id, List<PropertyDto> Property) : ICommand<AddpropertyResult>;
public record AddpropertyResult(bool IsSuccess);

internal class AddPropertyHandler(RequestDbContext dbContext) : ICommandHandler<AddPropertyCommand, AddpropertyResult>
{
    public async Task<AddpropertyResult> Handle(AddPropertyCommand command, CancellationToken cancellationToken)
    {
        var request = await dbContext.Requests.FindAsync(command.Id, cancellationToken);
        if (request is null) throw new RequestNotFoundException(command.Id);
        foreach (var property in command.Property)
        {
            request.AddProperty(NewProperty(property));
        }
        await dbContext.SaveChangesAsync(cancellationToken);
        return new AddpropertyResult(true);
    }
    private static RequestProperty NewProperty(PropertyDto property)
    {
        return RequestProperty.Of(property.PropertyType, property.BuildingType, property.SellingPrice);
    }
}