using System.Text.Json.Serialization;

namespace AuthentikNet.Api.Models;

/// <summary>
/// Request payload for partially updating an <see cref="ObjectAttribute"/>. Only assigned fields are sent.
/// </summary>
public class PatchedObjectAttributeRequest
{
    /// <summary>
    /// Target object content type string (for example, <c>authentik_core.user</c>).
    /// </summary>
    [JsonPropertyName("object_type")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ObjectType { get; set; }

    /// <summary>
    /// Whether this attribute definition is enabled.
    /// </summary>
    [JsonPropertyName("enabled")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Attribute key stored in the object's attributes map.
    /// </summary>
    [JsonPropertyName("key")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Key { get; set; }

    /// <summary>
    /// Human-readable label for this attribute.
    /// </summary>
    [JsonPropertyName("label")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Label { get; set; }

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
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ObjectAttributeTypeEnum? Type { get; set; }

    /// <summary>
    /// Optional UI grouping label.
    /// </summary>
    [JsonPropertyName("group")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Group { get; set; }

    /// <summary>
    /// Objects that are managed by authentik. Assign <c>null</c> to explicitly clear the value, or omit to leave unchanged.
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
}