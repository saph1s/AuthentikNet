using System.Text.Json.Serialization;

namespace AuthentikNet.Api.Models;

public class AccessDeniedChallenge
{
    [JsonPropertyName("flow_info")] public ContextualFlowInfo? FlowInfo { get; set; }
    [JsonPropertyName("component")] public string Component { get; set; } = "ak-stage-access-denied";
    [JsonPropertyName("response_errors")] public Dictionary<string, List<ErrorDetail>>? ResponseErrors { get; set; }
    [JsonPropertyName("pending_user")] public required string PendingUser { get; set; }

    [JsonPropertyName("pending_user_avatar")]
    public required string PendingUserAvatar { get; set; }

    [JsonPropertyName("error_message")] public string? ErrorMessage { get; set; }
}