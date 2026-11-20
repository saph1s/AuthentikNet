using AuthentikNet.Api.Models;
using AuthentikNet.Api.Utils;

namespace AuthentikNet.Api.Client.Core;

public partial class CoreApi
{
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
        var url = QueryStringBuilder.BuildQueryString("/core/groups/", new()
        {
            ["attributes"] = attributes,
            ["is_superuser"] = isSuperuser,
            ["members_by_pk"] = membersByPk,
            ["name"] = name,
            ["ordering"] = ordering,
            ["page"] = page,
            ["page_size"] = pageSize,
            ["search"] = search,
            ["members_by_username"] = membersByUsername,
            ["include_users"] = includeUsers,
            ["include_children"] = includeChildren,
            ["include_parents"] = includeParents,
            ["include_inherited_roles"] = includeInheritedRoles
        });

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