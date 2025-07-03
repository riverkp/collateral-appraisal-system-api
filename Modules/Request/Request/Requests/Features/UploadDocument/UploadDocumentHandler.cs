namespace Request.Requests.Features.UploadDocument;

public record UploadDocumentCommand(long Id, List<IFormFile> FormFiles) : ICommand<UploadDocumentResult>;
public record UploadDocumentResult(bool IsSuccess);

internal class UploadDocumentHandler(RequestDbContext dbContext) : ICommandHandler<UploadDocumentCommand, UploadDocumentResult>
{
    private readonly string[] permittedExtensions = [".pdf"];
    private const int maxUploadAttempts = 5;
    private const int maxFileSizeBytes = 5242880; // 5 MB

    public async Task<UploadDocumentResult> Handle(UploadDocumentCommand command, CancellationToken cancellationToken)
    {
        var request = await dbContext.Requests.Include(r => r.Documents).FirstOrDefaultAsync(r => r.Id == command.Id, cancellationToken) ?? throw new RequestNotFoundException(command.Id);

        Directory.CreateDirectory("Uploads");

        for (var i = 0; i < command.FormFiles.Count; i++)
        {
            var exceptionFileName = $"File #{i + 1}";
            var file = command.FormFiles[i] ?? throw new UploadDocumentException(exceptionFileName, "File is null");

            if (file.Length == 0)
                throw new UploadDocumentException(exceptionFileName, "File is empty");
            if (file.Length > maxFileSizeBytes)
                throw new UploadDocumentException(exceptionFileName, $"File size exceeded {maxFileSizeBytes} bytes");

            var fileExtension = Path.GetExtension(file.FileName);
            if (string.IsNullOrEmpty(fileExtension) || !permittedExtensions.Contains(fileExtension))
            {
                throw new UploadDocumentException(exceptionFileName, "File extension not recognized");
            }

            var (savePath, storageFileName) = await UploadFile(file, exceptionFileName, cancellationToken);

            var document = RequestDocument.Of(
                "DocType", // Doctype
                storageFileName,
                DateTime.Now,
                "Prefix", // Prefix
                1, // Set
                "", // Comment
                savePath);
            request.AddDocument(document);
        }

        await dbContext.SaveChangesAsync(cancellationToken);

        return new UploadDocumentResult(true);
    }

    private static async Task<(string, string)> UploadFile(IFormFile file, string exceptionFileName, CancellationToken cancellationToken)
    {
        var attempts = 0;
        while (attempts < maxUploadAttempts)
        {
            try
            {
                var generatedName = Path.GetRandomFileName();
                var storageFileName = $"{generatedName}.pdf";

                var savePath = Path.Combine("Uploads", storageFileName);
                using var stream = new FileStream(savePath, FileMode.CreateNew);

                await file.CopyToAsync(stream, cancellationToken);
                return (savePath, storageFileName);

            }
            catch (IOException)
            {
                attempts += 1;
            }
        }
        throw new UploadDocumentException(exceptionFileName, $"Cannot find suitable file name for storage after {attempts} attempts");
    }
}