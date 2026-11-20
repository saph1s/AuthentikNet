using System.Text.Json;
using System.Text.Json.Serialization;
using AuthentikNet.Api.Models;

namespace AuthentikNet.Api.Utils;

/// <summary>
/// Serializes assigned optional values without a wrapper object.
/// </summary>
public class OptionalJsonConverterFactory : JsonConverterFactory
{
    /// <inheritdoc />
    public override bool CanConvert(Type typeToConvert) =>
        typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(Optional<>);

    /// <inheritdoc />
    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options) =>
        (JsonConverter)Activator.CreateInstance(
            typeof(OptionalJsonConverter<>).MakeGenericType(typeToConvert.GetGenericArguments()))!;

    private class OptionalJsonConverter<T> : JsonConverter<Optional<T>>
    {
        public override bool HandleNull => true;

        public override Optional<T> Read(ref Utf8JsonReader reader, Type typeToConvert,
            JsonSerializerOptions options) =>
            new(JsonSerializer.Deserialize<T>(ref reader, options)!);

        public override void Write(Utf8JsonWriter writer, Optional<T> value, JsonSerializerOptions options)
        {
            if (!value.IsSet)
                throw new JsonException("Omitted optional properties must use JsonIgnoreCondition.WhenWritingDefault.");
            JsonSerializer.Serialize(writer, value.Value, options);
        }
    }
}