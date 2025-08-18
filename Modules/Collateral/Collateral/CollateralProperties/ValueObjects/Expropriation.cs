namespace Collateral.CollateralProperties.ValueObjects;

public class Expropriation : ValueObject
{
    public bool? IsExpropriate { get; }
    public string? IsExpropriateRemark { get; }
    public bool? InLineExpropriate { get; }
    public string? InLineExpropriatemark { get; }
    public string? RoyalDecree { get; }

    private Expropriation(
        bool? isExpropriate,
        string? isExpropriateRemark,
        bool? inLineExpropriate,
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
        bool? isExpropriate,
        string? isExpropriateRemark,
        bool? inLineExpropriate,
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
