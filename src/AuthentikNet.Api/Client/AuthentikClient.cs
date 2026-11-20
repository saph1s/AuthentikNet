using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using AuthentikNet.Api.Client.Admin;
using AuthentikNet.Api.Client.Core;
using AuthentikNet.Api.Client.Ssf;
using AuthentikNet.Api.Client.Tasks;

namespace AuthentikNet.Api.Client;

public class AuthentikClient
{
    private readonly HttpClient _client;
    private readonly AuthentikClientOptions _options;

    public AdminApi Admin { get; }
    public CoreApi Core { get; }
    public SsfApi Ssf { get; }
    public TasksApi Tasks { get; }

    public AuthentikClient(HttpClient client, AuthentikClientOptions options)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
        _options = options ?? throw new ArgumentNullException(nameof(options));

        _client.BaseAddress = new Uri(options.BaseUrl);
        _client.Timeout = options.Timeout;

        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", options.Token);
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("AuthentikNet.Api.Client",
            $"{GetType().Assembly.GetName().Version}")); // TODO: Need to set correct version

        Admin = new AdminApi(this);
        Core = new CoreApi(this);
        Ssf = new SsfApi(this);
        Tasks = new TasksApi(this);
    }

    public AuthentikClient(AuthentikClientOptions options) : this(new HttpClient(), options)
    {
    }

    /// <summary>
    /// Sends an HTTP request that does not return a JSON response body (for example, 204 No Content).
    /// </summary>
    public async Task SendAsync(HttpMethod method, string path, object? data = null,
        CancellationToken cancellationToken = default)
    {
        using var request = CreateRequest(method, path, data);
        using var response = await _client.SendAsync(request, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            await HandleError(response, cancellationToken);
        }
    }

    /// <summary>
    /// Sends an HTTP request and deserializes the JSON response body.
    /// </summary>
    public async Task<T> SendAsync<T>(HttpMethod method, string path, object? data = null,
        CancellationToken cancellationToken = default)
    {
        using var request = CreateRequest(method, path, data);
        using var response = await _client.SendAsync(request, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            await HandleError(response, cancellationToken);
        }

        return await DeserializeResponseAsync<T>(response, cancellationToken);
    }

    private HttpRequestMessage CreateRequest(HttpMethod method, string path, object? data)
    {
        var normalizedPath = path.StartsWith('/') ? path : "/" + path;
        var request = new HttpRequestMessage(method, _options.BaseUrl.TrimEnd('/') + normalizedPath);

        if (data != null)
        {
            request.Content = new StringContent(
                JsonSerializer.Serialize(data),
                Encoding.UTF8,
                "application/json"
            );
        }

        return request;
    }

    private async Task<T> DeserializeResponseAsync<T>(HttpResponseMessage response,
        CancellationToken cancellationToken)
    {
        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        return JsonSerializer.Deserialize<T>(content) ??
               throw new AuthentikException("Failed to deserialize response", 500);
    }

    private async Task HandleError(HttpResponseMessage response, CancellationToken cancellationToken)
    {
        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        string errorMessage;

        if (response.Content.Headers.ContentType?.MediaType == "application/json")
        {
            try
            {
                using var json = JsonDocument.Parse(content);
                errorMessage = json.RootElement.ToString();
            }
            catch (JsonException)
            {
                errorMessage = content;
            }
        }
        else
        {
            errorMessage = content;
        }

        throw response.StatusCode switch
        {
            HttpStatusCode.BadRequest => new AuthentikBadRequestException(errorMessage),
            HttpStatusCode.Unauthorized => new AuthentikUnauthorizedException(errorMessage),
            HttpStatusCode.Forbidden => new AuthentikForbiddenException(errorMessage),
            HttpStatusCode.NotFound => new AuthentikNotFoundException(errorMessage),
            _ => new AuthentikException(errorMessage, (int)response.StatusCode)
        };
    }
}