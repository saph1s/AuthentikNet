using AuthentikNet.Api.Models;

namespace AuthentikNet.Api.Client.Tasks;

/// <summary>
/// Task worker information.
/// </summary>
public class TasksApi(AuthentikClient client)
{
    /// <summary>
    /// Lists connected workers.
    /// </summary>
    public Task<List<Worker>> TasksWorkersList(CancellationToken cancellationToken = default) =>
        client.SendAsync<List<Worker>>(HttpMethod.Get, "/tasks/workers/", cancellationToken: cancellationToken);
}