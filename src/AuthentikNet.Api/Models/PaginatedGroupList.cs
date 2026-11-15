using System.Text.Json;
using System.Text.Json.Serialization;

namespace AuthentikNet.Api.Models;

public class PaginatedGroupList
{
    [JsonPropertyName("pagination")] public required Pagination Pagination { get; set; }
    [JsonPropertyName("results")] public required List<Group> Results { get; set; }
    [JsonPropertyName("autocomplete")] public required Dictionary<string, JsonElement> Autocomplete { get; set; }
}