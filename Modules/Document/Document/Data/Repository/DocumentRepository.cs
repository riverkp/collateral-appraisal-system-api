using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Document.Data.Repository;

public class DocumentRepository(DocumentDbContext dbContext) : IDocumentRepository
{
    public async Task<bool> UploadDocument(Documents.Models.Document document,
        CancellationToken cancellationToken = default)
    {
        dbContext.Documents.Add(document);
        await dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<Documents.Models.Document> GetDocumentById(long documentId,
        string rerateRequest, bool asNoTracking = true,
        CancellationToken cancellationToken = default)
    {
        var query = dbContext.Documents
            .Where(r => r.Id == documentId && r.RerateRequest == rerateRequest);

        if (asNoTracking) query = query.AsNoTracking();
        var document = await query.SingleOrDefaultAsync(cancellationToken);

        return document ?? throw new DocumentNotFoundException(documentId);
    }

    public async Task<bool> DeleteDocument(long id, string rerateRequest,
        CancellationToken cancellationToken)
    {
        var document = await GetDocumentById(id, rerateRequest, false, cancellationToken);

        dbContext.Documents.Remove(document);
        await dbContext.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.SaveChangesAsync(cancellationToken);
    }
}