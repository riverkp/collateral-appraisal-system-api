namespace Request.Contracts.Requests.Dtos;

public record VehicleDto(
    string? VehicleType,
    string? VehicleRegistrationNo,
    string? VehicleLocation
);
