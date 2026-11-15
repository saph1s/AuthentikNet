using AuthentikNet.Api.Models;
using AuthentikNet.Api.Utils;

namespace AuthentikNet.Api.Client.Core;

public partial class CoreApi
{
    private readonly AuthentikClient _client;

    public CoreApi(AuthentikClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Retrieve all users
    /// </summary>
    /// <param name="attributes">Attributes</param>
    /// <param name="email"></param>
    /// <param name="groupsByName"></param>
    /// <param name="groupsByPk"></param>
    /// <param name="isActive"></param>
    /// <param name="isSuperuser"></param>
    /// <param name="name"></param>
    /// <param name="ordering">Which field to use when ordering the results.</param>
    /// <param name="page">A page number within the paginated result set.</param>
    /// <param name="pageSize">Number of results to return per page.</param>
    /// <param name="path"></param>
    /// <param name="pathStartswith"></param>
    /// <param name="search">A search term.</param>
    /// <param name="type_"></param>
    /// <param name="username"></param>
    /// <param name="uuid"></param>
    /// <param name="includeGroups"></param>
    /// <param name="dateJoined">Exact account creation time.</param>
    /// <param name="dateJoinedGt">Accounts created after this time.</param>
    /// <param name="dateJoinedLt">Accounts created before this time.</param>
    /// <param name="includeRoles">Include expanded role objects; the server defaults to true.</param>
    /// <param name="lastLogin">Exact last login time.</param>
    /// <param name="lastLoginGt">Last login after this time.</param>
    /// <param name="lastLoginIsNull">Filter by whether last_login is null.</param>
    /// <param name="lastLoginLt">Last login before this time.</param>
    /// <param name="lastUpdated">Exact last update time.</param>
    /// <param name="lastUpdatedGt">Accounts updated after this time.</param>
    /// <param name="lastUpdatedLt">Accounts updated before this time.</param>
    /// <param name="rolesByName">Filter by role names.</param>
    /// <param name="rolesByPk">Filter by role UUIDs.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<PaginatedUserList> CoreUsersList(
        string? attributes = null,
        string? email = null,
        string[]? groupsByName = null,
        Guid[]? groupsByPk = null,
        bool? isActive = null,
        bool? isSuperuser = null,
        string? name = null,
        string? ordering = null,
        int? page = null,
        int? pageSize = null,
        string? path = null,
        string? pathStartswith = null,
        string? search = null,
        UserTypeEnum[]? type_ = null,
        string? username = null,
        Guid? uuid = null,
        bool includeGroups = true,
        CancellationToken cancellationToken = default,
        DateTimeOffset? dateJoined = null,
        DateTimeOffset? dateJoinedGt = null,
        DateTimeOffset? dateJoinedLt = null,
        bool? includeRoles = null,
        DateTimeOffset? lastLogin = null,
        DateTimeOffset? lastLoginGt = null,
        bool? lastLoginIsNull = null,
        DateTimeOffset? lastLoginLt = null,
        DateTimeOffset? lastUpdated = null,
        DateTimeOffset? lastUpdatedGt = null,
        DateTimeOffset? lastUpdatedLt = null,
        string[]? rolesByName = null,
        Guid[]? rolesByPk = null)

    {
        var parameters = new Dictionary<string, object?>
            {
                { "attributes", attributes },
                { "email", email },
                { "groups_by_name", groupsByName },
                { "groups_by_pk", groupsByPk },
                { "is_active", isActive },
                { "is_superuser", isSuperuser },
                { "name", name },
                { "ordering", ordering },
                { "page", page },
                { "page_size", pageSize },
                { "path", path },
                { "path_startswith", pathStartswith },
                { "search", search },
                { "type", type_ },
                { "username", username },
                { "uuid", uuid },
                { "include_groups", includeGroups },
                { "date_joined", dateJoined },
                { "date_joined__gt", dateJoinedGt },
                { "date_joined__lt", dateJoinedLt },
                { "include_roles", includeRoles },
                { "last_login", lastLogin },
                { "last_login__gt", lastLoginGt },
                { "last_login__isnull", lastLoginIsNull },
                { "last_login__lt", lastLoginLt },
                { "last_updated", lastUpdated },
                { "last_updated__gt", lastUpdatedGt },
                { "last_updated__lt", lastUpdatedLt },
                { "roles_by_name", rolesByName },
                { "roles_by_pk", rolesByPk }
            }.Where(kv => kv.Value != null)
            .ToDictionary(kv => kv.Key, kv => kv.Value);

        var url = QueryStringBuilder.BuildQueryString("/core/users/", parameters);

        return await _client.SendAsync<PaginatedUserList>(HttpMethod.Get, url,
            cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Create user
    /// </summary>
    /// <param name="data">UserRequest</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<User> CoreUsersCreate(UserRequest data, CancellationToken cancellationToken = default)
    {
        return await _client.SendAsync<User>(HttpMethod.Post, "/core/users/", data, cancellationToken);
    }

    /// <summary>
    /// Retrieve user
    /// </summary>
    /// <param name="id">A unique integer value identifying this User.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<User> CoreUsersRetrieve(int id, CancellationToken cancellationToken = default)
    {
        return await _client.SendAsync<User>(HttpMethod.Get, $"/core/users/{id}/",
            cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Partial update user
    /// </summary>
    /// <param name="id">A unique integer value identifying this User.</param>
    /// <param name="data">UserRequest</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<User> CoreUsersPartialUpdate(int id, PatchedUserRequest data,
        CancellationToken cancellationToken = default)
    {
        return await _client.SendAsync<User>(HttpMethod.Patch, $"/core/users/{id}/", data, cancellationToken);
    }

    /// <summary>
    /// Retrieve all groups
    /// </summary>
    /// <param name="membersByPk"></param>
    /// <param name="attributes">Attributes</param>
    /// <param name="isSuperuser"></param>
    /// <param name="name"></param>
    /// <param name="ordering">Which field to use when ordering the results.</param>
    /// <param name="page">A page number within the paginated result set.</param>
    /// <param name="pageSize">Number of results to return per page.</param>
    /// <param name="search">A search term.</param>
    /// <param name="membersByUsername"></param>
    /// <param name="includeUsers"></param>
    /// <param name="includeChildren">Include expanded child groups.</param>
    /// <param name="includeParents">Include expanded parent groups.</param>
    /// <param name="includeInheritedRoles">Include inherited role objects.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<PaginatedGroupList> CoreGroupsList(
        int[]? membersByPk = null,
        string? attributes = null,
        bool? isSuperuser = null,
        string? name = null,
        string? ordering = null,
        int? page = null,
        int? pageSize = null,
        string? search = null,
        string[]? membersByUsername = null,
        bool includeUsers = true,
        CancellationToken cancellationToken = default,
        bool includeChildren = false,
        bool includeParents = false,
        bool includeInheritedRoles = false)
    {
        var parameters = new Dictionary<string, object?>
            {
                { "attributes", attributes },
                { "is_superuser", isSuperuser },
                { "members_by_pk", membersByPk },
                { "name", name },
                { "ordering", ordering },
                { "page", page },
                { "page_size", pageSize },
                { "search", search },
                { "members_by_username", membersByUsername },
                { "include_users", includeUsers },
                { "include_children", includeChildren },
                { "include_parents", includeParents },
                { "include_inherited_roles", includeInheritedRoles }
            }.Where(kv => kv.Value != null)
            .ToDictionary(kv => kv.Key, kv => kv.Value);

        var url = QueryStringBuilder.BuildQueryString("/core/groups/", parameters);

        return await _client.SendAsync<PaginatedGroupList>(HttpMethod.Get, url, cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Retrieve group
    /// </summary>
    /// <param name="id">A UUID string identifying this Group.</param>
    /// <param name="includeUsers"></param>
    /// <param name="includeChildren">Include expanded child groups.</param>
    /// <param name="includeParents">Include expanded parent groups.</param>
    /// <param name="includeInheritedRoles">Include inherited role objects.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Group> CoreGroupsRetrieve(
        Guid id,
        bool includeUsers = true,
        CancellationToken cancellationToken = default,
        bool includeChildren = false,
        bool includeParents = false,
        bool includeInheritedRoles = false)
    {
        var url = QueryStringBuilder.BuildQueryString($"/core/groups/{id}/", new()
        {
            ["include_users"] = includeUsers,
            ["include_children"] = includeChildren,
            ["include_parents"] = includeParents,
            ["include_inherited_roles"] = includeInheritedRoles
        });

        return await _client.SendAsync<Group>(HttpMethod.Get, url, cancellationToken: cancellationToken);
    }
}