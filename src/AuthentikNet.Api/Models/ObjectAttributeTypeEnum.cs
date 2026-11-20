using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using AuthentikNet.Api.Utils;

namespace AuthentikNet.Api.Models;

/// <summary>
/// Value type of an <see cref="ObjectAttribute"/>.
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter<ObjectAttributeTypeEnum>))]
public enum ObjectAttributeTypeEnum
{
    /// <summary>
    /// Text value.
    /// </summary>
    [EnumMember(Value = "text")] Text,

    /// <summary>
    /// Numeric value.
    /// </summary>
    [EnumMember(Value = "number")] Number,

    /// <summary>
    /// Boolean value.
    /// </summary>
    [EnumMember(Value = "boolean")] Boolean
}