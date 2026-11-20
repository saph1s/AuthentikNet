using System.Text.Json.Serialization;

namespace AuthentikNet.Api.Models;

public class SettingsFlags
{
    [JsonPropertyName("core_default_app_access")]
    public required bool CoreDefaultAppAccess { get; set; }

    [JsonPropertyName("enterprise_audit_include_expanded_diff")]
    public required bool EnterpriseAuditIncludeExpandedDiff { get; set; }

    [JsonPropertyName("flows_continuous_login")]
    public required bool FlowsContinuousLogin { get; set; }

    // Deprecated by authentik, but still required by the 2026.8.6 contract.
    [JsonPropertyName("flows_refresh_others")]
    public required bool FlowsRefreshOthers { get; set; }
}