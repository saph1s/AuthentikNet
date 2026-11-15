using System.Text.Json.Serialization;

namespace AuthentikNet.Api.Models;

public class ContextualFlowInfo
{
    [JsonPropertyName("title")] public string? Title { get; set; }
    [JsonPropertyName("background")] public string? Background { get; set; }

    [JsonPropertyName("background_themed_urls")]
    public ThemedUrls? BackgroundThemedUrls { get; set; }

    [JsonPropertyName("cancel_url")] public required string CancelUrl { get; set; }
    [JsonPropertyName("layout")] public required ContextualFlowInfoLayoutEnum Layout { get; set; }
}