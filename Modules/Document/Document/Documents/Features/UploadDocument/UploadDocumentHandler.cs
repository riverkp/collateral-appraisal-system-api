namespace Document.Documents.Features.UploadDocument;

internal class UploadDocumentHandler(IDocumentRepository documentRepository) : ICommandHandler<UploadDocumentCommand, UploadDocumentResult>
{
    private readonly string[] permittedExtensions = [".pdf", ".PDF"];
    private const long maxSize = 5 * 1024 * 1024; //5MB
    private const string uploadFolder = "Upload";
    public async Task<UploadDocumentResult> Handle(UploadDocumentCommand command, CancellationToken cancellationToken)
    {
        var result = new List<UploadResultDto>();
        var documents = command.Documents;

        if (documents.Count > 5) throw new UploadDocumentException("File upload limit exceeded (maximum 5 files).");

        if (!Directory.Exists(uploadFolder)) Directory.CreateDirectory(uploadFolder);

        foreach (var file in documents)
        {
            try
            {
                var (recordDocument, recordResult) = await ProcessFile(file, command.RerateRequest, command.RerateId, cancellationToken);
                await documentRepository.UploadDocument(recordDocument, cancellationToken);
                result.Add(recordResult);
            }
            catch (UploadDocumentException exception)
            {
                result.Add(new UploadResultDto(false, exception.Message));
            }


        }
        return new UploadDocumentResult(result);
    }

    private async Task<(Models.Document, UploadResultDto)> ProcessFile(IFormFile file, string rerateRequest, long rerateId, CancellationToken cancellationToken)
    {
        var filename = Path.GetFileName(file.FileName);
        var fileExtention = Path.GetExtension(file.FileName);
        var filenameValid = await HashFileContentAsync(file, cancellationToken) + fileExtention; // for valid content file when try to upload same file with this diff name
        var savePath = Path.Combine(uploadFolder, filenameValid);

        if (file is null) throw new UploadDocumentException("File is null");
        else if (file.Length <= 0) throw new UploadDocumentException("File is Empty");
        else if (file.Length > maxSize) throw new UploadDocumentException($"File size exceeded {maxSize} bytes");
        else if (File.Exists(savePath)) throw new UploadDocumentException("Duplicate file detected. This PDF has already been uploaded.");
        else if (string.IsNullOrEmpty(fileExtention) || !permittedExtensions.Contains(fileExtention)) throw new UploadDocumentException("File extension not recognized");
        
        
        using var stream = new FileStream(savePath, FileMode.CreateNew);

        await file.CopyToAsync(stream, cancellationToken);

        var recordDocument = UploadNewDocument(rerateRequest, rerateId, filename, savePath);

        return (recordDocument, new UploadResultDto(true, "Success"));
    }

    private static Models.Document UploadNewDocument(string rerateRequest, long rerateId, string filename, string savePath)
    {
        var recordDocument = Models.Document.Create(
            rerateRequest,
            rerateId, //rerateId
            "DocType", // Doctype 
            filename,
            DateTime.Now,
            "Prefix", // Prefix
            1, // Set
            "", // Comment
            savePath
        );

        return recordDocument;
    }
    private static async Task<string> HashFileContentAsync(IFormFile file, CancellationToken cancellationToken)
    {
        using var stream = file.OpenReadStream();
        var hash = await SHA256.Create().ComputeHashAsync(stream, cancellationToken);
        return Convert.ToHexString(hash);
    }
}