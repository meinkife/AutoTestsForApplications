using System;
using System.Text.Json.Serialization;

public class UserResponseDTO
{
    [JsonPropertyName("name")]
public UserDataDTO Data { get; set; }
}

