namespace Collateral.CollateralProperties.ValueObjects;

public class ConsecutiveArea : ValueObject
{
    public string? NConsecutiveArea { get; }
    public decimal? NEstimateLength { get; }
    public string? SConsecutiveArea { get; }
    public decimal? SEstimateLength { get; }
    public string? EConsecutiveArea { get; }
    public decimal? EEstimateLength { get; }
    public string? WConsecutiveArea { get; }
    public decimal? WEstimateLength { get; }

    private ConsecutiveArea(
        string? nConsecutiveArea,
        decimal? nEstimateLength,
        string? sConsecutiveArea,
        decimal? sEstimateLength,
        string? eConsecutiveArea,
        decimal? eEstimateLength,
        string? wConsecutiveArea,
        decimal? wEstimateLength
    )
    {
        NConsecutiveArea = nConsecutiveArea;
        NEstimateLength = nEstimateLength;
        SConsecutiveArea = sConsecutiveArea;
        SEstimateLength = sEstimateLength;
        EConsecutiveArea = eConsecutiveArea;
        EEstimateLength = eEstimateLength;
        WConsecutiveArea = wConsecutiveArea;
        WEstimateLength = wEstimateLength;
    }

    public static ConsecutiveArea Create(
        string? nConsecutiveArea,
        decimal? nEstimateLength,
        string? sConsecutiveArea,
        decimal? sEstimateLength,
        string? eConsecutiveArea,
        decimal? eEstimateLength,
        string? wConsecutiveArea,
        decimal? wEstimateLength
    )
    {
        return new ConsecutiveArea(
            nConsecutiveArea,
            nEstimateLength,
            sConsecutiveArea,
            sEstimateLength,
            eConsecutiveArea,
            eEstimateLength,
            wConsecutiveArea,
            wEstimateLength
        );
    }
}
