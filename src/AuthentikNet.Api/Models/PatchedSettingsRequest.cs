using System.Text.Json.Serialization;

namespace AuthentikNet.Api.Models;

/// <summary>
/// Settings PATCH request. Only assigned fields are sent.
/// </summary>
public class PatchedSettingsRequest : SettingsBase
{
    /// <summary>
    /// Feature flags, omitted unless assigned. All flags are required when provided.
    /// </summary>
    [JsonPropertyName("flags")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SettingsFlags? Flags { get; set; }
}