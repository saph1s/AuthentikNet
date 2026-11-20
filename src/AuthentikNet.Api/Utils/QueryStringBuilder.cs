using System.Collections;
using System.Globalization;
using System.Text.Json;

namespace AuthentikNet.Api.Utils;

public static class QueryStringBuilder
{
    public static string BuildQueryString(string baseUrl, Dictionary<string, object?> parameters)
    {
        var queryParams = new List<string>();

        foreach (var (key, value) in parameters)
        {
            switch (value)
            {
                case null:
                    continue;
                case string str:
                    queryParams.Add($"{Uri.EscapeDataString(key)}={Uri.EscapeDataString(str)}");
                    break;
                case IEnumerable enumerable:
                {
                    queryParams.AddRange(from object? item in enumerable
                        select $"{Uri.EscapeDataString(key)}={Uri.EscapeDataString(FormatValue(item))}");
                    break;
                }
                default:
                    queryParams.Add($"{Uri.EscapeDataString(key)}={Uri.EscapeDataString(FormatValue(value))}");
                    break;
            }
        }

        if (queryParams.Count == 0)
            return baseUrl;

        return baseUrl + (baseUrl.Contains('?') ? "&" : "?") + string.Join("&", queryParams);
    }

    /// <summary>
    /// Formats a value for inclusion in a query string, handling special cases for null, booleans, enums, and date/time values.
    /// </summary>
    private static string FormatValue(object? value) => value switch
    {
        null => string.Empty,
        bool boolean => boolean ? "true" : "false",
        Enum enumValue => JsonSerializer.SerializeToElement(enumValue, enumValue.GetType()).GetString()
                          ?? throw new JsonException("Enum query values must serialize to strings."),
        DateTimeOffset date => date.ToString("O", CultureInfo.InvariantCulture),
        DateTime date => date.ToString("O", CultureInfo.InvariantCulture),
        IFormattable formattable => formattable.ToString(null, CultureInfo.InvariantCulture),
        _ => value.ToString() ?? string.Empty
    };
}