namespace Request.Requests.Features.UploadDocument;

public record UploadDocumentCommand(long Id, List<IFormFile> FormFiles) : ICommand<UploadDocumentResult>;
public record UploadDocumentResult(bool IsSuccess, List<UploadDocumentStatus> Details);
public record UploadDocumentStatus(bool IsSuccess, string Comment = "");

internal class UploadDocumentHandler(RequestDbContext dbContext) : ICommandHandler<UploadDocumentCommand, UploadDocumentResult>
{
    private readonly string[] permittedExtensions = [".pdf"];
    private const int maxUploadAttempts = 5;
    private const int maxFileSizeBytes = 5 * 1024 * 1024; // 5 MB

    public async Task<UploadDocumentResult> Handle(UploadDocumentCommand command, CancellationToken cancellationToken)
    {
        var request = await dbContext.Requests.Include(r => r.Documents).FirstOrDefaultAsync(r => r.Id == command.Id, cancellationToken) ?? throw new RequestNotFoundException(command.Id);

        Directory.CreateDirectory("Uploads");
        List<UploadDocumentStatus> response = [];
        bool isSuccess = true;

        for (var i = 0; i < command.FormFiles.Count; i++)
        {
            var file = command.FormFiles[i];
            try
            {
                await ProcessFile(request, file, cancellationToken);
                response.Add(new UploadDocumentStatus(true));
            }
            catch (UploadDocumentException exception)
            {
                response.Add(new UploadDocumentStatus(false, exception.Message));
                isSuccess = false;
            }
            catch (Exception exception)
            {
                response.Add(new UploadDocumentStatus(false, exception.Message));
                isSuccess = false;
            }
        }

        await dbContext.SaveChangesAsync(cancellationToken);

        return new UploadDocumentResult(isSuccess, response);
    }

    private async Task<bool> ProcessFile(Models.Request request, IFormFile file, CancellationToken cancellationToken)
    {
        if (file == null)
            throw new UploadDocumentException("File is null");
        if (file.Length == 0)
            throw new UploadDocumentException("File is empty");
        if (file.Length > maxFileSizeBytes)
            throw new UploadDocumentException($"File size exceeded {maxFileSizeBytes} bytes");

        var fileExtension = Path.GetExtension(file.FileName);
        if (string.IsNullOrEmpty(fileExtension) || !permittedExtensions.Contains(fileExtension))
        {
            throw new UploadDocumentException("File extension not recognized");
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

        return true;
    }

    private static async Task<(string, string)> UploadFile(IFormFile file, CancellationToken cancellationToken)
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
        throw new UploadDocumentException($"Cannot find suitable file name for storage after {attempts} attempts");
    }
}