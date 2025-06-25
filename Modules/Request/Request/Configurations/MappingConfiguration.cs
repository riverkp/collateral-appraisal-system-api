namespace Request.Configurations;

public static class MappingConfiguration
{
    public static void ConfigureMappings()
    {
        TypeAdapterConfig<AddressDto, Address>
            .NewConfig()
            .ConstructUsing(src => Address.Create(
                src.HouseNo,
                src.RoomNo,
                src.FloorNo,
                src.LocationIdentifier,
                src.Moo,
                src.Soi,
                src.Road,
                src.SubDistrict,
                src.District,
                src.Province,
                src.Postcode
            ));

        TypeAdapterConfig<RequestorDto, Requestor>
            .NewConfig()
            .ConstructUsing(src => Requestor.Create(
                src.RequestorEmpId,
                src.RequestorName,
                src.RequestorEmail,
                src.RequestorContactNo,
                src.RequestorAo,
                src.RequestorBranch,
                src.RequestorBusinessUnit,
                src.RequestorDepartment,
                src.RequestorSection,
                src.RequestorCostCenter
            ));
    }
}