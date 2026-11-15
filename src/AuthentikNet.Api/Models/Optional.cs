using System.Text.Json.Serialization;
using AuthentikNet.Api.Utils;

namespace AuthentikNet.Api.Models;

/// <summary>Distinguishes an omitted JSON property from an explicitly assigned value, including null.</summary>
/// <typeparam name="T">The property's value type.</typeparam>
[JsonConverter(typeof(OptionalJsonConverterFactory))]
public readonly struct Optional<T>
{
    private readonly T _value;

    /// <summary>Whether a value was explicitly assigned.</summary>
    public bool IsSet { get; }

    /// <summary>The assigned value. Throws if the property was omitted.</summary>
    public T Value => IsSet ? _value : throw new InvalidOperationException("No value was assigned.");

    /// <summary>Creates an explicitly assigned value.</summary>
    public Optional(T value)
    {
        _value = value;
        IsSet = true;
    }

    /// <summary>Assigns a value without an explicit wrapper.</summary>
    public static implicit operator Optional<T>(T value) => new(value);
}