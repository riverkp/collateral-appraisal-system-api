namespace Document.Documents.Features.UploadDocument;
public class UploadDocumentEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/documents/{rerateRequest}/{rerateId:long}",
            async (string rerateRequest, long rerateId, HttpRequest request, ISender sender) =>
        {
            var form = await request.ReadFormAsync();

            var command = new UploadDocumentCommand([.. form.Files], rerateRequest, rerateId);

            var result = await sender.Send(command);

            var response = result.Adapt<UploadDocumentResult>();

            return Results.Ok(response.Result);
        }).DisableAntiforgery();
    }
}
