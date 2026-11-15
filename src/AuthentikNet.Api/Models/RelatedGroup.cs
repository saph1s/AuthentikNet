using System.Text.Json;
using System.Text.Json.Serialization;

namespace AuthentikNet.Api.Models;

public class RelatedGroup
{
    [JsonPropertyName("pk")] public required Guid Pk { get; init; }
    [JsonPropertyName("name")] public required string Name { get; set; }
    [JsonPropertyName("is_superuser")] public bool IsSuperUser { get; set; }
    [JsonPropertyName("attributes")] public Dictionary<string, JsonElement> Attributes { get; set; } = new();
    [JsonPropertyName("group_uuid")] public required Guid GroupUuid { get; init; }
}