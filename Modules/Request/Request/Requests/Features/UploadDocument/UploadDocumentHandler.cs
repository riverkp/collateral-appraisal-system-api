using System.Security.Cryptography;

namespace Request.Requests.Features.UploadDocument;

public record UploadDocumentCommand(long Id, List<IFormFile> FormFiles) : ICommand<UploadDocumentResult>;
public record UploadDocumentResult(List<UploadResultDto> Results);

public record UploadResultDto(bool IsSuccess, string FileName, string Detail);

internal class UploadDocumentHandler(RequestDbContext dbContext) : ICommandHandler<UploadDocumentCommand, UploadDocumentResult>
{
    private const string UploadsFolder = "Uploads";
    private const long MaxFileSize = 5 * 1024 * 1024; // 5 MB

    public async Task<UploadDocumentResult> Handle(UploadDocumentCommand command, CancellationToken cancellationToken)
    {
        var request = await dbContext.Requests
            .Include(r => r.Documents)
            .FirstOrDefaultAsync(r => r.Id == command.Id, cancellationToken)
            ?? throw new RequestNotFoundException(command.Id);

        if (!Directory.Exists(UploadsFolder))
            Directory.CreateDirectory(UploadsFolder);

        var results = new List<UploadResultDto>();

        foreach (var file in command.FormFiles)
        {
            if (file is null)
            {
                results.Add(new UploadResultDto(false, "Unknown", "File is null"));
                continue;
            }

            if (file.Length >= MaxFileSize)
            {
                results.Add(new UploadResultDto(false, file.FileName, "File size exceeds limit"));
                continue;
            }

            using var ms = new MemoryStream();
            await file.CopyToAsync(ms, cancellationToken);
            ms.Position = 0;

            string hash = Convert.ToHexStringLower(await SHA256.Create().ComputeHashAsync(ms, cancellationToken));
            ms.Position = 0;

            var extension = Path.GetExtension(file.FileName);
            var fileName = hash + extension;
            var savePath = Path.Combine(UploadsFolder, fileName);

            if (File.Exists(savePath))
            {
                results.Add(new UploadResultDto(false, file.FileName, "Duplicate file detected in Uploads"));
                continue;
            }

            using (var stream = new FileStream(savePath, FileMode.Create))
            {
                await ms.CopyToAsync(stream, cancellationToken);
            }

            var document = RequestDocument.Of(
                "DocType", // Doctype
                fileName,
                DateTime.Now,
                "Prefix", // Prefix
                1, // Set
                "", // Comment
                savePath);
            request.AddDocument(document);

            results.Add(new UploadResultDto(true, file.FileName, "Upload success"));
        }

        await dbContext.SaveChangesAsync(cancellationToken);
        return new UploadDocumentResult(results);
    }
}