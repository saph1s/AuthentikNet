using System.Text.Json.Serialization;

namespace AuthentikNet.Api.Models;

/// <summary>
/// Django content type metadata describing the target model of an object attribute.
/// </summary>
public class ContentType
{
    /// <summary>
    /// Content type identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>
    /// Application label of the model.
    /// </summary>
    [JsonPropertyName("app_label")]
    public required string AppLabel { get; init; }

    /// <summary>
    /// Model name.
    /// </summary>
    [JsonPropertyName("model")]
    public required string Model { get; init; }

    /// <summary>
    /// Plural display name of the model.
    /// </summary>
    [JsonPropertyName("verbose_name_plural")]
    public required string VerboseNamePlural { get; init; }

    /// <summary>
    /// Fully qualified model identifier (<c>app_label.model</c>).
    /// </summary>
    [JsonPropertyName("fully_qualified_model")]
    public required string FullyQualifiedModel { get; init; }
}