using System.Text.Json;
using System.Text.Json.Serialization;

namespace AuthentikNet.Api.Models;

/// <summary>
/// Paginated list of <see cref="ObjectAttribute"/> records.
/// </summary>
public class PaginatedObjectAttributeList
{
    /// <summary>
    /// Pagination metadata.
    /// </summary>
    [JsonPropertyName("pagination")]
    public required Pagination Pagination { get; set; }

    /// <summary>
    /// Object attributes on the current page.
    /// </summary>
    [JsonPropertyName("results")]
    public required List<ObjectAttribute> Results { get; set; }

    /// <summary>
    /// Autocomplete metadata returned by the API.
    /// </summary>
    [JsonPropertyName("autocomplete")]
    public required Dictionary<string, JsonElement> Autocomplete { get; set; }
}