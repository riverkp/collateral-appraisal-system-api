namespace Request.Requests.Features.GetRequestById;

//public record GetRequestByIdRequest();
public record GetRequestByIdResponse(RequestDto Request);
public class GetRequestByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/request/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new GetRequestByIdQuery(id));

            return Results.Ok(result);
        })
        .WithName("GetRequestById")
        .Produces<GetRequestByIdResponse>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .WithSummary("Get request by ID")
        .WithDescription("Get request by ID");
    }
}
