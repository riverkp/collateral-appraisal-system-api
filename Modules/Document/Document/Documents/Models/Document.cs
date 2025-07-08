namespace Document.Documents.Models;

public class Document : Aggregate<long>
{
    public string RerateRequest { get; private set; } = default!;
    public long RerateId { get; private set; } = default!;
    public string DocType { get; private set; } = default!;
    public string Filename { get; private set; } = default!;
    public DateTime UploadTime { get; private set; } = default!;
    public string Prefix { get; private set; } = default!;
    public short Set { get; private set; } = default!;
    public string Comment { get; private set; } = default!;
    public string FilePath { get; private set; } = default!;

    private Document()
    {
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("SonarQube", "S107:Methods should not have too many parameters")]
    private Document(
        string rerateRequest,
        long rerateId,
        string docType,
        string filename,
        DateTime uploadTime,
        string prefix,  
        short set,
        string comment,
        string filePath
        )
    {
        RerateRequest = rerateRequest;
        RerateId = rerateId;
        DocType = docType;
        Filename = filename;
        UploadTime = uploadTime;
        Prefix = prefix;
        Set = set;
        Comment = comment;
        FilePath = filePath;
    }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("SonarQube", "S107:Methods should not have too many parameters")]

    public static Document Create(
        string rerateRequest,
        long rerateId,
        string docType,
        string filename,
        DateTime uploadTime,
        string prefix,
        short set,
        string comment,
        string filePath
    )
    {
        
        ArgumentNullException.ThrowIfNull(rerateRequest);
        ArgumentNullException.ThrowIfNull(docType);
        ArgumentNullException.ThrowIfNull(filename);
        ArgumentNullException.ThrowIfNull(prefix);
        ArgumentNullException.ThrowIfNull(comment);
        ArgumentNullException.ThrowIfNull(filePath);

        return new Document(
            rerateRequest,
            rerateId,
            docType,
            filename,
            uploadTime,
            prefix,
            set,
            comment,
            filePath);
    }
}