using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AutoTestsForApplications.DTO;

public record ProfileDTO
(
    [property: JsonPropertyName("fullName")]
    string FullName,

    [property: JsonPropertyName("age")]
    int Age,

    [property: JsonPropertyName("address")]
    UserAddressDTO Address,

    [property: JsonPropertyName("tags")]
    List<string> Tags
);