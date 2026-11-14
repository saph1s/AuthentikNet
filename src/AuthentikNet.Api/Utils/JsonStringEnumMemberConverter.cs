using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AuthentikNet.Api.Utils;

/// <summary>
/// Converts only the API wire values explicitly declared with EnumMember.
/// </summary>
public class JsonStringEnumMemberConverter<T> : JsonConverter<T> where T : struct, Enum
{
    private static readonly Dictionary<string, T> ValuesByName = new(StringComparer.Ordinal);
    private static readonly Dictionary<T, string> NamesByValue = new();

    static JsonStringEnumMemberConverter()
    {
        foreach (var field in typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static))
        {
            var name = field.GetCustomAttribute<EnumMemberAttribute>()?.Value;
            if (name is null)
                continue;

            var value = (T)field.GetValue(null)!;
            ValuesByName.Add(name, value);
            NamesByValue.Add(value, name);
        }
    }

    /// <inheritdoc />
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.String)
            throw new JsonException($"Expected a string value for {typeof(T).Name}.");

        var name = reader.GetString()!;
        return ValuesByName.TryGetValue(name, out var value)
            ? value
            : throw new JsonException($"Unknown {typeof(T).Name} value: {name}");
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        if (!NamesByValue.TryGetValue(value, out var name))
            throw new JsonException($"Unknown {typeof(T).Name} value: {value}");

        writer.WriteStringValue(name);
    }
}