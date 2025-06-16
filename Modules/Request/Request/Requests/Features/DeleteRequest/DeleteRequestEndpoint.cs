namespace Request.Requests.Features.DeleteRequest;

public record DeleteRequestResponse(bool IsSuccess);

public class DeleteRequestEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/request/{id}", async (long id, ISender sender) =>
            {
                var result = await sender.Send(new DeleteRequestCommand(id));
                var response = result.Adapt<DeleteRequestResponse>();
                return Results.Ok(response);
            })
            .WithName("DeleteRequest")
            .Produces<DeleteRequestResponse>()
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Delete request by ID")
            .WithDescription(
                "Deletes a request by its ID. If the request does not exist, a 404 Not Found error is returned.");
    }
}