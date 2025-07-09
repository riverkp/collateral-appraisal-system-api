namespace Document.Documents.Features.DeleteDocument;

public record DeleteDocumentCommand(long Id, string RerateRequest) : ICommand<DeleteDocumentResult>;