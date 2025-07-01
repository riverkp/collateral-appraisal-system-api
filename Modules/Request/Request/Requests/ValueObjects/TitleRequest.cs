namespace Request.Requests.ValueObjects;

public record TitleDocument
{
    public TitleDocument()
    {
    }

    private TitleDocument
    (
        string docType,
        string fileName,
        DateTime uploadDate,
        string prefix,
        short set,
        string comment,
        string filePath
    )
    {
        DocType = docType;
        FileName = fileName;
        UploadDate = uploadDate;
        Prefix = prefix;
        Set = set;
        Comment = comment;
        FilePath = filePath;
    }

    public string DocType { get; } 
    public string FileName { get; } 
    public DateTime UploadDate { get; } 
    public string Prefix { get; }
    public short Set { get; } 
    public string Comment { get; } 
    public string FilePath { get; } 

    public static TitleDocument Of
    (
        string docType,
        string fileName,
        DateTime uploadDate,
        string prefix,
        short set,
        string comment,
        string filePath
    )
    {
        ArgumentException.ThrowIfNullOrEmpty(docType);
        ArgumentException.ThrowIfNullOrEmpty(fileName);
        ArgumentException.ThrowIfNullOrEmpty(prefix);
        ArgumentException.ThrowIfNullOrEmpty(comment);
        ArgumentException.ThrowIfNullOrEmpty(filePath);
        
        return new TitleDocument
        (
            docType,
            fileName,
            uploadDate,
            prefix,
            set,
            comment,
            filePath
        );   
    }
}