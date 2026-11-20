using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using AuthentikNet.Api.Utils;

namespace AuthentikNet.Api.Models;

[JsonConverter(typeof(JsonStringEnumMemberConverter<ContextualFlowInfoLayoutEnum>))]
public enum ContextualFlowInfoLayoutEnum
{
    [EnumMember(Value = "stacked")] Stacked,
    [EnumMember(Value = "content_left")] ContentLeft,
    [EnumMember(Value = "content_right")] ContentRight,
    [EnumMember(Value = "sidebar_left")] SidebarLeft,
    [EnumMember(Value = "sidebar_right")] SidebarRight,

    [EnumMember(Value = "sidebar_left_frame_background")]
    SidebarLeftFrameBackground,

    [EnumMember(Value = "sidebar_right_frame_background")]
    SidebarRightFrameBackground
}