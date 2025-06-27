using AddCustomerRequest = System.Collections.Generic.List<Request.Contracts.Requests.Dtos.RequestCustomerDto>;

namespace Request.Requests.Features.AddCustomer;

public record AddCustomerResponse(bool IsSuccess);

public class AddCustomerEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/request/{id}/addcustomer", async (long id, AddCustomerRequest request, ISender sender) =>
            {
                var command = new AddCustomerCommand(id, request);
                var result = await sender.Send(command);
                var response = result.Adapt<AddCustomerResponse>();
                return Results.Ok(response);
            })
            .WithName("AddCustomer")
            .Produces<AddCustomerResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Add new customers to an existing request")
            .WithDescription(
                "Creates new customers in the system. The request details are provided in the request body.");
    }
}