namespace AuthentikNet.Api.Client.Core;

/// <summary>
/// Core authentik API endpoints.
/// </summary>
public partial class CoreApi
{
    private readonly AuthentikClient _client;

    /// <summary>
    /// Initializes a new instance of <see cref="CoreApi"/>.
    /// </summary>
    /// <param name="client">Parent authentik HTTP client.</param>
    public CoreApi(AuthentikClient client)
    {
        _client = client;
    }
}