using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using AuthentikNet.Api.Utils;

namespace AuthentikNet.Api.Models;

[JsonConverter(typeof(JsonStringEnumMemberConverter<SSFStreamStatusEnum>))]
public enum SSFStreamStatusEnum
{
    [EnumMember(Value = "enabled")] Enabled,
    [EnumMember(Value = "paused")] Paused,
    [EnumMember(Value = "disabled")] Disabled,

    [EnumMember(Value = "disabled_deleted")]
    DisabledDeleted
}