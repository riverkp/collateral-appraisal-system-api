using Carter;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Request.Requests.Features.DeleteRequest;

public class DeleteRequestEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/requests/{id:guid}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteRequestCommand(id));
            return result.IsSuccess
                ? Results.Ok(result)
                : Results.NotFound();
        })
        .WithName("DeleteRequest")
        .Produces<DeleteRequestResult>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Delete a request")
        .WithDescription("Deletes a request by its ID.");
    }
}