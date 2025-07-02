namespace Request.Requests.Features.UploadDocument;

public record UploadDocumentCommand(long Id, List<IFormFile> FormFiles) : ICommand<UploadDocumentResult>;
public record UploadDocumentResult(bool IsSuccess);

internal class UploadDocumentHandler(RequestDbContext dbContext) : ICommandHandler<UploadDocumentCommand, UploadDocumentResult>
{
    public async Task<UploadDocumentResult> Handle(UploadDocumentCommand command, CancellationToken cancellationToken)
    {
        var request = await dbContext.Requests.Include(r => r.Documents).FirstOrDefaultAsync(r => r.Id == command.Id, cancellationToken) ?? throw new RequestNotFoundException(command.Id);

        Directory.CreateDirectory("Uploads");

        foreach (var file in command.FormFiles)
        {
            var savePath = Path.Combine("Uploads", file.FileName);
            using var stream = new FileStream(savePath, FileMode.Create);

            await file.CopyToAsync(stream, cancellationToken);
            var document = RequestDocument.Of(
                "", // file.ContentType is too long
                file.FileName,
                DateTime.Now,
                "",
                1,
                "",
                savePath);
            request.AddDocument(document);
        }

        await dbContext.SaveChangesAsync(cancellationToken);

        return new UploadDocumentResult(true);
    }
}