namespace Document.Documents.Features.UploadDocument;

public record UploadDocumentRequest(List<IFormFile> Doucments);
public record UploadDocumentResponse(List<UploadResultDto> Response);

public class UploadDocumentEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/document/{rerateRequest}/{rerateId:long}",
        async (string rerateRequest, long rerateId, HttpRequest request, ISender sender) =>
        {
            var form = await request.ReadFormAsync();

            var command = new UploadDocumentCommand([.. form.Files], rerateRequest, rerateId);

            var result = await sender.Send(command);

            return Results.Ok(result.Result);
        }).DisableAntiforgery();
    }
}
