namespace Collateral.CollateralProperties.ValueObjects;

public class CondominiumFacility : ValueObject
{
    public string? CondoFacility { get; private set; }
    public string? CondoFacilityOther { get; private set; }

    private CondominiumFacility(string? condoFacility, string? condoFacilityOther)
    {
        CondoFacility = condoFacility;
        CondoFacilityOther = condoFacilityOther;
    }

    public static CondominiumFacility Create(string? condoFacility, string? condoFacilityOther)
    {
        return new CondominiumFacility(condoFacility, condoFacilityOther);
    }
}
