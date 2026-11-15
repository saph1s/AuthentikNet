using System.Text.Json.Serialization;

namespace AuthentikNet.Api.Models;

public class ErrorDetail
{
    [JsonPropertyName("string")] public required string String { get; set; }
    [JsonPropertyName("code")] public required string Code { get; set; }
}