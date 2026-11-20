using System.Text.Json;
using System.Text.Json.Serialization;

namespace AuthentikNet.Api.Models;

public class User
{
    [JsonPropertyName("pk")] public required int Pk { get; init; }
    [JsonPropertyName("username")] public required string Username { get; set; }
    [JsonPropertyName("name")] public required string Name { get; set; }
    [JsonPropertyName("is_active")] public bool IsActive { get; set; }
    [JsonPropertyName("last_login")] public DateTime? LastLogin { get; set; }
    [JsonPropertyName("is_superuser")] public required bool IsSuperUser { get; init; }
    [JsonPropertyName("groups")] public List<Guid> Groups { get; set; } = [];
    [JsonPropertyName("groups_obj")] public required List<PartialGroup>? GroupsObj { get; init; }
    [JsonPropertyName("email")] public string Email { get; set; } = string.Empty;
    [JsonPropertyName("avatar")] public required string Avatar { get; init; }

    [JsonPropertyName("attributes")] public Dictionary<string, JsonElement> Attributes { get; set; } = new();

    [JsonPropertyName("uid")] public required string Uid { get; init; }
    [JsonPropertyName("path")] public string Path { get; set; } = string.Empty;

    [JsonPropertyName("type")] public UserTypeEnum Type { get; set; }

    [JsonPropertyName("uuid")] public required Guid Uuid { get; init; }
    [JsonPropertyName("date_joined")] public required DateTime DateJoined { get; init; }
    [JsonPropertyName("roles")] public List<Guid> Roles { get; set; } = [];
    [JsonPropertyName("roles_obj")] public required List<Role>? RolesObj { get; init; }

    [JsonPropertyName("password_change_date")]
    public required DateTime PasswordChangeDate { get; init; }

    [JsonPropertyName("last_updated")] public required DateTime LastUpdated { get; init; }
}