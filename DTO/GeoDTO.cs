using System.Text.Json.Serialization;

namespace AutoTestsForApplications.DTO;

public record GeoDTO
(
    [property: JsonPropertyName("lat")]
    double Lat,

    [property: JsonPropertyName("lng")]
    double Lng
);