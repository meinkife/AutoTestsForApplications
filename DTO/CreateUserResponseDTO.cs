using System;
using System.Text.Json.Serialization;

public class CreateUserResponseDTO

{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("job")]
    public string Job { get; set; }

    [JsonPropertyName("id")]
    public string ID { get; set; }

    [JsonPropertyName("created_At")]
    public string CreatedAt { get; set; }
}

