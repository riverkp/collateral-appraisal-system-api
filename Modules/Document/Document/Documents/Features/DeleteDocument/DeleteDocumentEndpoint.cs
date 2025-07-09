using Microsoft.AspNetCore.Mvc;

namespace Document.Documents.Features.DeleteDocument;

public class DeleteDocumentEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/documents/{id:long}/{rerateRequest:alpha}",
            async ([FromRoute]long id, [FromRoute]string rerateRequest ,[FromServices]ISender sender) =>
        {
            var command = new DeleteDocumentCommand(id, rerateRequest);

            var result = await sender.Send(command);

            var response = result.Adapt<DeleteDocumentResponse>();

            return Results.Ok(response);
        });
    }
}