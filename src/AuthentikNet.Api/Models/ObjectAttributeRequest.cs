using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace AuthentikNet.Api.Models;

/// <summary>
/// Request payload for creating or replacing an <see cref="ObjectAttribute"/>.
/// </summary>
public class ObjectAttributeRequest
{
    /// <summary>
    /// Target object content type string (for example, <c>authentik_core.user</c>).
    /// </summary>
    [JsonPropertyName("object_type")]
    public required string ObjectType { get; set; }

    /// <summary>
    /// Whether this attribute definition is enabled. Defaults to <c>true</c> on the server.
    /// </summary>
    [JsonPropertyName("enabled")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Enabled { get; set; }

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
    /// Optional validation regular expression.
    /// </summary>
    [JsonPropertyName("regex")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
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
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Group { get; set; }

    /// <summary>
    /// Objects that are managed by authentik. Assign <c>null</c> to explicitly clear the value, or omit to leave unset.
    /// </summary>
    [JsonPropertyName("managed")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<string?> Managed { get; set; }

    /// <summary>
    /// Whether values of this attribute must be unique across objects.
    /// </summary>
    [JsonPropertyName("is_unique")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? IsUnique { get; set; }

    /// <summary>
    /// Whether this attribute is required.
    /// </summary>
    [JsonPropertyName("is_required")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? IsRequired { get; set; }

    /// <summary>
    /// Creates an empty <see cref="ObjectAttributeRequest"/>.
    /// </summary>
    public ObjectAttributeRequest()
    {
    }

    /// <summary>
    /// Creates an <see cref="ObjectAttributeRequest"/> with all required fields populated.
    /// </summary>
    /// <param name="objectType">Target object content type string.</param>
    /// <param name="key">Attribute key.</param>
    /// <param name="label">Human-readable label.</param>
    /// <param name="type">Attribute value type.</param>
    [SetsRequiredMembers]
    public ObjectAttributeRequest(string objectType, string key, string label, ObjectAttributeTypeEnum type)
    {
        ObjectType = objectType;
        Key = key;
        Label = label;
        Type = type;
    }
}