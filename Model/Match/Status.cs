using System.Text.Json.Serialization;

namespace kyniusBETAPI.Model.Match;

public class Status
{
    [JsonIgnore]
    public int Id { get; set; }
    [JsonPropertyName("long")]
    public string? Long { get; set; }
    [JsonPropertyName("short")]
    public string? Short { get; set; }
    [JsonPropertyName("elapsed")]
    public int? Elapsed { get; set; }
}