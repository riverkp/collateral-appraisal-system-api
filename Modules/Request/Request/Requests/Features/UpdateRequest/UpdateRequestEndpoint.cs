using UpdateRequestRequest = Request.Contracts.Requests.Dtos.RequestDto;

namespace Request.Requests.Features.UpdateRequest;

//public record UpdateRequestRequest(RequestDto Request);

public record UpdateRequestResponse(bool IsSuccess);

public class UpdateRequestEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/requests/{id}", async (long id, UpdateRequestRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateRequestCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<UpdateRequestResponse>();
                return Results.Ok(response);
            })
            .WithName("UpdateRequest")
            .Produces<UpdateRequestResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Update an existing request")
            .WithDescription(
                "Updates an existing request in the system. The request details are provided in the request body.");
    }
}