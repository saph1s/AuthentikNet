using System.Text.Json.Serialization;

namespace AuthentikNet.Api.Models;

public class Pagination
{
    [JsonPropertyName("next")] public required double Next { get; set; }
    [JsonPropertyName("previous")] public required double Previous { get; set; }
    [JsonPropertyName("count")] public required double Count { get; set; }
    [JsonPropertyName("current")] public required double Current { get; set; }
    [JsonPropertyName("total_pages")] public required double TotalPages { get; set; }
    [JsonPropertyName("start_index")] public required double StartIndex { get; set; }
    [JsonPropertyName("end_index")] public required double EndIndex { get; set; }
}