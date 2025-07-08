using System.Security.Cryptography;
using System.Text;
using Document.Documents.Features.UploadDocument;
using Microsoft.AspNetCore.Http;

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

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.SaveChangesAsync(cancellationToken);
    }
}