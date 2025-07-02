using AddPropertyRequest = System.Collections.Generic.List<Request.Contracts.Requests.Dtos.PropertyDto>;

namespace Request.Requests.Features.AddProperty;

public record AddPropertyResponse(bool IsSuccess);

public class AddPropertyEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/requests/{id}/addproperty", async (long id, AddPropertyRequest request, ISender sender) =>
        {
            var command = request.Adapt<AddPropertyCommand>() with { Id = id, Property = request };
            var result = await sender.Send(command);
            var response = result.Adapt<AddPropertyResponse>();

            return response;
        })
        .WithName("AddProperty")
        .Produces<AddPropertyResponse>()
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Add a list property")
        .WithDescription(
            "Add list a new property in the system");
    }
}