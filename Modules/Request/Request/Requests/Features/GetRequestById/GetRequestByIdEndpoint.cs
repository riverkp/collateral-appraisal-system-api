using RequestDto = Request.Contracts.Requests.Dtos.RequestDto;

namespace Request.Requests.Features.GetRequestById;

public record GetRequestByIdResponse(RequestDto Request);

public class GetRequestByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/request/{id}", async (long id, ISender sender) =>
            {
                var result = await sender.Send(new GetRequestByIdQuery(id));

                return Results.Ok(result.Request);
            })
            .WithName("GetRequestById")
            .Produces<GetRequestByIdResponse>()
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get request by ID")
            .WithDescription("Get request by ID");
    }
}