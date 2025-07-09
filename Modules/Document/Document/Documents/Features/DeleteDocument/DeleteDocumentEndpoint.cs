using Microsoft.AspNetCore.Mvc;

namespace Document.Documents.Features.DeleteDocument;

public class DeleteDocumentEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/documents/{id:long}",
            async ([FromRoute]long id,[FromServices]ISender sender) =>
        {
            var command = new DeleteDocumentCommand(id);

            var result = await sender.Send(command);

            var response = result.Adapt<DeleteDocumentResponse>();

            return Results.Ok(response);
        });
    }
}