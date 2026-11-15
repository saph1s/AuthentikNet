using System.Text.Json.Serialization;

namespace AuthentikNet.Api.Models;

public class Provider
{
    [JsonPropertyName("pk")] public required int Pk { get; set; }
    [JsonPropertyName("name")] public required string Name { get; set; }

    [JsonPropertyName("authentication_flow")]
    public Guid? AuthenticationFlow { get; set; }

    [JsonPropertyName("authorization_flow")]
    public Guid? AuthorizationFlow { get; set; }

    [JsonPropertyName("invalidation_flow")]
    public Guid? InvalidationFlow { get; set; }

    [JsonPropertyName("property_mappings")]
    public List<Guid>? PropertyMappings { get; set; }

    [JsonPropertyName("component")] public required string Component { get; set; }

    [JsonPropertyName("assigned_application_slug")]
    public required string? AssignedApplicationSlug { get; set; }

    [JsonPropertyName("assigned_application_name")]
    public required string? AssignedApplicationName { get; set; }

    [JsonPropertyName("assigned_backchannel_application_slug")]
    public required string? AssignedBackchannelApplicationSlug { get; set; }

    [JsonPropertyName("assigned_backchannel_application_name")]
    public required string? AssignedBackchannelApplicationName { get; set; }

    [JsonPropertyName("verbose_name")] public required string VerboseName { get; set; }

    [JsonPropertyName("verbose_name_plural")]
    public required string VerboseNamePlural { get; set; }

    [JsonPropertyName("meta_model_name")] public required string MetaModelName { get; set; }
}