using System.Text.Json.Serialization;

namespace AuthentikNet.Api.Models;

/// <summary>
/// Settings PUT request. The API requires all feature flags.
/// </summary>
public class SettingsRequest : SettingsBase
{
    /// <summary>
    /// Instance feature flags.
    /// </summary>
    [JsonPropertyName("flags")]
    public required SettingsFlags Flags { get; set; }
}