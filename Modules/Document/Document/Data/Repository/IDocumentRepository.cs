namespace Document.Data.Repository;

public interface IDocumentRepository
{
    Task<bool> UploadDocument(Documents.Models.Document document,
        CancellationToken cancellationToken = default);

    Task<Documents.Models.Document> GetDocumentById(long documentId,
        string rerateRequest, bool asNoTracking = true,
        CancellationToken cancellationToken = default);

    Task<bool> DeleteDocument(long id, string rerateRequest,
        CancellationToken cancellationToken = default);

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}