namespace Document.Documents.Features.UploadDocument;
public record UploadDocumentCommand(
    List<IFormFile> Documents,
    string RerateRequest,
    long RerateId
) : ICommand<UploadDocumentResult>;