namespace Collateral.CollateralProperties.ValueObjects;

public class LandTitleDocumentDetail : ValueObject
{
    public string TitleNo { get; } = default!;
    public string BookNo { get; } = default!;
    public string PageNo { get; } = default!;
    public string LandNo { get; } = default!;
    public string SurveyNo { get; } = default!;
    public string? SheetNo { get; }

    private LandTitleDocumentDetail(
        string titleNo,
        string bookNo,
        string pageNo,
        string landNo,
        string surveyNo,
        string? sheetNo
    )
    {
        TitleNo = titleNo;
        BookNo = bookNo;
        PageNo = pageNo;
        LandNo = landNo;
        SurveyNo = surveyNo;
        SheetNo = sheetNo;
    }

    public static LandTitleDocumentDetail Create(
        string titleNo,
        string bookNo,
        string pageNo,
        string landNo,
        string surveyNo,
        string? sheetNo
    )
    {
        return new LandTitleDocumentDetail(
            titleNo,
            bookNo,
            pageNo,
            landNo,
            surveyNo,
            sheetNo
        );
    }
}