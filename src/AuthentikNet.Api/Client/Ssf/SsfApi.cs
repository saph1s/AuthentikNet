using AuthentikNet.Api.Models;
using AuthentikNet.Api.Utils;

namespace AuthentikNet.Api.Client.Ssf;

public class SsfApi
{
    private readonly AuthentikClient _client;

    public SsfApi(AuthentikClient client)
    {
        _client = client;
    }

    /// <summary>
    /// SSFStream Viewset
    /// </summary>
    /// <param name="deliveryMethod"></param>
    /// <param name="endpointUrl"></param>
    /// <param name="ordering">Which field to use when ordering the results</param>
    /// <param name="page">A page number within the paginated result set</param>
    /// <param name="pageSize">Number of results to return per page</param>
    /// <param name="provider"></param>
    /// <param name="search">A search term</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<PaginatedSSFStreamList> SsfStreamsList(DeliveryMethodEnum? deliveryMethod = null,
        string? endpointUrl = null,
        string? ordering = null, int? page = null,
        int? pageSize = null, int? provider = null, string? search = null,
        CancellationToken cancellationToken = default)
    {
        var url = QueryStringBuilder.BuildQueryString("/ssf/streams/", new()
        {
            ["delivery_method"] = deliveryMethod,
            ["endpoint_url"] = endpointUrl,
            ["ordering"] = ordering,
            ["page"] = page,
            ["page_size"] = pageSize,
            ["provider"] = provider,
            ["search"] = search
        });

        return await _client.SendAsync<PaginatedSSFStreamList>(HttpMethod.Get, url,
            cancellationToken: cancellationToken);
    }
}