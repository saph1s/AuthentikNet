using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using AuthentikNet.Api.Utils;

namespace AuthentikNet.Api.Models;

[JsonConverter(typeof(JsonStringEnumMemberConverter<EventsRequestedEnum>))]
public enum EventsRequestedEnum
{
    [EnumMember(Value = "https://schemas.openid.net/secevent/caep/event-type/session-revoked")]
    CAEP_EVENT_TYPE_SESSION_REVOKED,

    [EnumMember(Value = "https://schemas.openid.net/secevent/caep/event-type/credential-change")]
    CAEP_EVENT_TYPE_CREDENTIAL_CHANGE,

    [EnumMember(Value = "https://schemas.openid.net/secevent/ssf/event-type/verification")]
    SSF_EVENT_TYPE_VERIFICATION,

    [EnumMember(Value = "https://schemas.openid.net/secevent/caep/event-type/token-claims-change")]
    CAEP_EVENT_TYPE_TOKEN_CLAIMS_CHANGE,

    [EnumMember(Value = "https://schemas.openid.net/secevent/caep/event-type/assurance-level-change")]
    CAEP_EVENT_TYPE_ASSURANCE_LEVEL_CHANGE,

    [EnumMember(Value = "https://schemas.openid.net/secevent/caep/event-type/device-compliance-change")]
    CAEP_EVENT_TYPE_DEVICE_COMPLIANCE_CHANGE,

    [EnumMember(Value = "https://schemas.openid.net/secevent/caep/event-type/session-established")]
    CAEP_EVENT_TYPE_SESSION_ESTABLISHED,

    [EnumMember(Value = "https://schemas.openid.net/secevent/caep/event-type/session-presented")]
    CAEP_EVENT_TYPE_SESSION_PRESENTED,

    [EnumMember(Value = "https://schemas.openid.net/secevent/caep/event-type/risk-level-change")]
    CAEP_EVENT_TYPE_RISK_LEVEL_CHANGE
}