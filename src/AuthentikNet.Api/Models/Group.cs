using System.Text.Json;
using System.Text.Json.Serialization;

namespace AuthentikNet.Api.Models;

public class Group
{
    [JsonPropertyName("pk")] public required Guid Pk { get; init; }
    [JsonPropertyName("num_pk")] public required int NumPk { get; init; }
    [JsonPropertyName("name")] public required string Name { get; set; }
    [JsonPropertyName("is_superuser")] public bool IsSuperUser { get; set; }
    [JsonPropertyName("parents")] public List<Guid> Parents { get; set; } = [];
    [JsonPropertyName("parents_obj")] public required List<RelatedGroup>? ParentsObj { get; init; }
    [JsonPropertyName("users")] public List<int> Users { get; set; } = [];
    [JsonPropertyName("users_obj")] public required List<GroupMember>? UsersObj { get; init; }

    [JsonPropertyName("attributes")] public Dictionary<string, JsonElement> Attributes { get; set; } = new();

    [JsonPropertyName("roles")] public List<Guid> Roles { get; set; } = [];
    [JsonPropertyName("roles_obj")] public required List<Role> RolesObj { get; init; }

    [JsonPropertyName("inherited_roles_obj")]
    public required List<Role>? InheritedRolesObj { get; init; }

    [JsonPropertyName("children")] public required List<Guid> Children { get; init; }
    [JsonPropertyName("children_obj")] public required List<RelatedGroup>? ChildrenObj { get; init; }
}