using System.Text.Json;
using System.Text.Json.Serialization;

namespace AuthentikNet.Api.Models;

public class PaginatedUserList
{
    [JsonPropertyName("pagination")] public required Pagination Pagination { get; set; }
    [JsonPropertyName("results")] public required List<User> Results { get; set; }
    [JsonPropertyName("autocomplete")] public required Dictionary<string, JsonElement> Autocomplete { get; set; }
}