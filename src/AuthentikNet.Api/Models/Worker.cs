using System.Text.Json.Serialization;

namespace AuthentikNet.Api.Models;

public class Worker
{
    [JsonPropertyName("worker_id")] public required string WorkerId { get; set; }
    [JsonPropertyName("version")] public required string Version { get; set; }
    [JsonPropertyName("version_matching")] public required bool VersionMatching { get; set; }
}