using System.Text.Json.Serialization;

namespace AuthentikNet.Api.Models;

public class ThemedUrls
{
    [JsonPropertyName("light")] public string? Light { get; set; }
    [JsonPropertyName("dark")] public string? Dark { get; set; }
}