namespace Document.Data.Repository;

public interface IDocumentRepository
{
    Task<bool> UploadDocument(Documents.Models.Document document,
        CancellationToken cancellationToken = default);

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}