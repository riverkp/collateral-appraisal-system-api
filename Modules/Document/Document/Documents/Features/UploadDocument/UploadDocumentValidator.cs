namespace Document.Documents.Features.UploadDocument;

public class UploadDocumentCommandValidator : AbstractValidator<UploadDocumentCommand>
{
    public UploadDocumentCommandValidator()
    {
        RuleFor(x => x.Documents)
            .NotNull()
            .WithMessage("Document is required.")
            .Must(document => document.Count > 0)
            .WithMessage("At least one document is required.");

        RuleFor(x => x.RerateRequest)
            .NotNull()
            .WithMessage("RerateRequest is required.");

        RuleFor(x => x.RerateId)
            .NotNull()
            .WithMessage("RerateId is required.")
            .GreaterThan(0)
            .WithMessage("RerateId must be greater than 0.");
    }
}