namespace Collateral.CollateralProperties.ValueObjects;

public class Expropriation : ValueObject
{
    public string? IsExpropriate { get; }
    public string? IsExpropriateRemark { get; }
    public string? InLineExpropriate { get; }
    public string? InLineExpropriatemark { get; }
    public string? RoyalDecree { get; }

    private Expropriation(
        string? isExpropriate,
        string? isExpropriateRemark,
        string? inLineExpropriate,
        string? inLineExpropriatemark,
        string? royalDecree
    )
    {
        IsExpropriate = isExpropriate;
        IsExpropriateRemark = isExpropriateRemark;
        InLineExpropriate = inLineExpropriate;
        InLineExpropriatemark = inLineExpropriatemark;
        RoyalDecree = royalDecree;
    }

    public static Expropriation Create(
        string? isExpropriate,
        string? isExpropriateRemark,
        string? inLineExpropriate,
        string? inLineExpropriatemark,
        string? royalDecree
    )
    {
        return new Expropriation(
            isExpropriate,
            isExpropriateRemark,
            inLineExpropriate,
            inLineExpropriatemark,
            royalDecree
        );
    }
}