using AuthentikNet.Api.Models;
using AuthentikNet.Api.Utils;

namespace AuthentikNet.Api.Client.Core;

public partial class CoreApi
{
    /// <summary>
    /// Retrieve all object attributes.
    /// </summary>
    /// <param name="enabled">Filter by whether the attribute is enabled.</param>
    /// <param name="objectTypeAppLabel">Filter by target content type app label.</param>
    /// <param name="objectTypeModel">Filter by target content type model name.</param>
    /// <param name="ordering">Which field to use when ordering the results.</param>
    /// <param name="page">A page number within the paginated result set.</param>
    /// <param name="pageSize">Number of results to return per page.</param>
    /// <param name="search">A search term.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A paginated list of object attributes.</returns>
    public async Task<PaginatedObjectAttributeList> CoreObjectAttributesList(
        bool? enabled = null,
        string? objectTypeAppLabel = null,
        string? objectTypeModel = null,
        string? ordering = null,
        int? page = null,
        int? pageSize = null,
        string? search = null,
        CancellationToken cancellationToken = default)
    {
        var url = QueryStringBuilder.BuildQueryString("/core/object_attributes/", new Dictionary<string, object?>
        {
            ["enabled"] = enabled,
            ["object_type__app_label"] = objectTypeAppLabel,
            ["object_type__model"] = objectTypeModel,
            ["ordering"] = ordering,
            ["page"] = page,
            ["page_size"] = pageSize,
            ["search"] = search
        });

        return await _client.SendAsync<PaginatedObjectAttributeList>(HttpMethod.Get, url,
            cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Create a new object attribute.
    /// </summary>
    /// <param name="data">Object attribute creation payload.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created object attribute.</returns>
    public async Task<ObjectAttribute> CoreObjectAttributesCreate(
        ObjectAttributeRequest data,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(data);
        return await _client.SendAsync<ObjectAttribute>(HttpMethod.Post, "/core/object_attributes/", data,
            cancellationToken);
    }

    /// <summary>
    /// Retrieve an object attribute by UUID.
    /// </summary>
    /// <param name="attributeId">A UUID string identifying this Object Attribute.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The object attribute.</returns>
    public async Task<ObjectAttribute> CoreObjectAttributesRetrieve(
        Guid attributeId,
        CancellationToken cancellationToken = default)
    {
        return await _client.SendAsync<ObjectAttribute>(HttpMethod.Get, $"/core/object_attributes/{attributeId}/",
            cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Replace an existing object attribute.
    /// </summary>
    /// <param name="attributeId">A UUID string identifying this Object Attribute.</param>
    /// <param name="data">Full object attribute payload.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The updated object attribute.</returns>
    public async Task<ObjectAttribute> CoreObjectAttributesUpdate(
        Guid attributeId,
        ObjectAttributeRequest data,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(data);
        return await _client.SendAsync<ObjectAttribute>(HttpMethod.Put, $"/core/object_attributes/{attributeId}/",
            data, cancellationToken);
    }

    /// <summary>
    /// Partially update an existing object attribute.
    /// </summary>
    /// <param name="attributeId">A UUID string identifying this Object Attribute.</param>
    /// <param name="data">Partial object attribute payload.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The updated object attribute.</returns>
    public async Task<ObjectAttribute> CoreObjectAttributesPartialUpdate(
        Guid attributeId,
        PatchedObjectAttributeRequest data,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(data);
        return await _client.SendAsync<ObjectAttribute>(HttpMethod.Patch, $"/core/object_attributes/{attributeId}/",
            data, cancellationToken);
    }

    /// <summary>
    /// Delete an object attribute.
    /// </summary>
    /// <param name="attributeId">A UUID string identifying this Object Attribute.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    public async Task CoreObjectAttributesDestroy(
        Guid attributeId,
        CancellationToken cancellationToken = default)
    {
        await _client.SendAsync(HttpMethod.Delete, $"/core/object_attributes/{attributeId}/",
            cancellationToken: cancellationToken);
    }
}