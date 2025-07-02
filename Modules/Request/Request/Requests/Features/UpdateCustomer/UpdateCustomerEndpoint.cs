using UpdateCustomerRequest = System.Collections.Generic.List<Request.Contracts.Requests.Dtos.RequestCustomerDto>;

namespace Request.Requests.Features.UpdateCustomer;

public record UpdateCustomerResponse(bool IsSuccess);

public class UpdateCustomerEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/request/{id}/updatecustomer", async (long id, UpdateCustomerRequest request, ISender sender) =>
            {
                var command = new UpdateCustomerCommand(id, request);
                var result = await sender.Send(command);
                var response = result.Adapt<UpdateCustomerResponse>();
                return Results.Ok(response);
            })
            .WithName("UpdateCustomer")
            .Produces<UpdateCustomerResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Update customers of an existing request")
            .WithDescription(
                "Replace customers of an existing request. The request details are provided in the request body.");
    }
}