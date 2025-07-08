namespace Document.Configurations;

public static class MappingConfiguration
{
    public static void ConfigureMappings()
    {
        TypeAdapterConfig<DocumentDto, Documents.Models.Document>
            .NewConfig()
            .ConstructUsing(src => Documents.Models.Document.Create(
                src.RerateRequest,
                src.RerateId,
                src.DocType,
                src.Filename,
                src.UploadTime,
                src.Prefix,
                src.Set,
                src.Comment,
                src.FilePath
            ));
    }
}