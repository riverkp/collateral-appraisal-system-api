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

        if (!Directory.Exists("Uploads")) Directory.CreateDirectory("Uploads");

        foreach (var file in command.FormFiles)
        {
            if (file is null)
                throw new DocumentNotFoundException("Unknown file");
            if (file.Length == 0)
                throw new DocumentNotFoundException("File is empty");
            if (file.Length > maxFileSizeBytes)
                throw new DocumentNotFoundException($"File size exceeded {maxFileSizeBytes} bytes");

            var fileExtension = Path.GetExtension(file.FileName);

            if (string.IsNullOrEmpty(fileExtension) || !permittedExtensions.Contains(fileExtension))
            {
                throw new DocumentNotFoundException("File extension not recognized");
            }

            var (savePath, storageFileName) = await UploadFile(file, cancellationToken);

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

    private static async Task<(string, string)> UploadFile(IFormFile file, CancellationToken cancellationToken) {
        var attempts = 0;
        while (attempts < maxUploadAttempts)
        {
            try
            {
                var generatedName = Path.GetRandomFileName();
                var storageFileName =  $"{generatedName}.pdf";

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
        throw new DocumentNotFoundException($"Cannot find suitable file name for storage after {attempts} attempts");
    }
}