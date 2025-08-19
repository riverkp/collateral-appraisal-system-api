namespace Collateral.CollateralProperties.ValueObjects;

public class LandTitleDocumentDetail : ValueObject
{
    public string TitleNo { get; }
    public string BookNo { get; }
    public string PageNo { get; }
    public string LandNo { get; }
    public string SurveyNo { get; }
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
        return new LandTitleDocumentDetail(titleNo, bookNo, pageNo, landNo, surveyNo, sheetNo);
    }
}
