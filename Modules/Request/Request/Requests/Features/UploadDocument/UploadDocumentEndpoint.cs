namespace Request.Requests.Features.UploadDocument;

public record UploadDocumentResponse(bool IsSuccess);

public class UploadDocumentEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/requests/{id}/uploadDocuments", async (long id, HttpRequest request, ISender sender) =>
        {
            var form = await request.ReadFormAsync();
            var command = new UploadDocumentCommand(id, [.. form.Files]);
            var result = await sender.Send(command);
            var response = result.Adapt<UploadDocumentResponse>();
            return Results.Ok(response);
        }).DisableAntiforgery();
    }
}