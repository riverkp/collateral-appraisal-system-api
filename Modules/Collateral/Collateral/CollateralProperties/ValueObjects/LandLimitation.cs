namespace Collateral.CollateralProperties.ValueObjects;

public class LandLimitation : ValueObject
{
    public Expropriation Expropriation { get; private set; } = default!;
    public Encroachment Encroachment { get; private set; } = default!;
    public string? Electricity { get; private set; }
    public decimal? ElectricityDistance { get; private set; }
    public bool? IsLandlocked { get; private set; }
    public string? IsLandlockedRemark { get; private set; }
    public ForestBoundary ForestBoundary { get; private set; } = default!;
    public string? LimitationOther { get; private set; }

    private LandLimitation() { }

    private LandLimitation(
        Expropriation expropriation,
        Encroachment encroachment,
        string? electricity,
        decimal? electricityDistance,
        bool? isLandlocked,
        string? isLandlockedRemark,
        ForestBoundary forestBoundary,
        string? limitationOther
    )
    {
        Expropriation = expropriation;
        Encroachment = encroachment;
        Electricity = electricity;
        ElectricityDistance = electricityDistance;
        IsLandlocked = isLandlocked;
        IsLandlockedRemark = isLandlockedRemark;
        ForestBoundary = forestBoundary;
        LimitationOther = limitationOther;
    }

    public static LandLimitation Create(
        Expropriation expropriation,
        Encroachment encroachment,
        string? electricity,
        decimal? electricityDistance,
        bool? isLandlocked,
        string? isLandlockedRemark,
        ForestBoundary forestBoundary,
        string? limitationOther
    )
    {
        return new LandLimitation(
            expropriation,
            encroachment,
            electricity,
            electricityDistance,
            isLandlocked,
            isLandlockedRemark,
            forestBoundary,
            limitationOther
        );
    }
}
