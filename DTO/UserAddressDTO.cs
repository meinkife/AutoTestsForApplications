using System.Text.Json.Serialization;

namespace AutoTestsForApplications.DTO;

public record UserAddressDTO
(
    [property: JsonPropertyName("street")]
    string Street,

    [property: JsonPropertyName("city")]
    string City,

    [property: JsonPropertyName("geo")]
    GeoDTO Geo
);