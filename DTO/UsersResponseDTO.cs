using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AutoTestsForApplications.DTO;

public record UsersResponseDTO
(
    [property: JsonPropertyName("data")]
    List<UserDTO> Data
);