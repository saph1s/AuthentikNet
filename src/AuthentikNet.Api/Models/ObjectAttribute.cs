using System.Text.Json.Serialization;

namespace AuthentikNet.Api.Models;

/// <summary>
/// Object attribute definition returned by the authentik API.
/// </summary>
public class ObjectAttribute
{
    /// <summary>
    /// Unique UUID identifying this object attribute.
    /// </summary>
    [JsonPropertyName("pk")]
    public required Guid Pk { get; init; }

    /// <summary>
    /// Target object content type string (for example, <c>authentik_core.user</c>).
    /// </summary>
    [JsonPropertyName("object_type")]
    public required string ObjectType { get; set; }

    /// <summary>
    /// Expanded target object content type metadata.
    /// </summary>
    [JsonPropertyName("object_type_obj")]
    public required ContentType ObjectTypeObj { get; init; }

    /// <summary>
    /// Whether this attribute definition is enabled.
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool Enabled { get; set; } = true;

    /// <summary>
    /// Creation timestamp.
    /// </summary>
    [JsonPropertyName("created")]
    public required DateTime Created { get; init; }

    /// <summary>
    /// Attribute key stored in the object's attributes map.
    /// </summary>
    [JsonPropertyName("key")]
    public required string Key { get; set; }

    /// <summary>
    /// Human-readable label for this attribute.
    /// </summary>
    [JsonPropertyName("label")]
    public required string Label { get; set; }

    /// <summary>
    /// Timestamp of the last update.
    /// </summary>
    [JsonPropertyName("last_updated")]
    public required DateTime LastUpdated { get; init; }

    /// <summary>
    /// Optional validation regular expression.
    /// </summary>
    [JsonPropertyName("regex")]
    public string? Regex { get; set; }

    /// <summary>
    /// Data type of this attribute.
    /// </summary>
    [JsonPropertyName("type")]
    public required ObjectAttributeTypeEnum Type { get; set; }

    /// <summary>
    /// Optional UI grouping label.
    /// </summary>
    [JsonPropertyName("group")]
    public string? Group { get; set; }

    /// <summary>
    /// Objects that are managed by authentik. These objects are created and updated automatically.
    /// </summary>
    [JsonPropertyName("managed")]
    public string? Managed { get; set; }

    /// <summary>
    /// Whether values of this attribute must be unique across objects.
    /// </summary>
    [JsonPropertyName("is_unique")]
    public bool IsUnique { get; set; }

    /// <summary>
    /// Whether this attribute is required.
    /// </summary>
    [JsonPropertyName("is_required")]
    public bool IsRequired { get; set; }
}