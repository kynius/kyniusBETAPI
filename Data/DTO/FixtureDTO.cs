using System.Text.Json.Serialization;
using kyniusBETAPI.Model.Match;

namespace kyniusBETAPI.Data.DTO;

public class FixtureDTO
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("referee")]
    public string? Referee { get; set; }
    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }
    [JsonPropertyName("date")]
    public DateTime? Date { get; set; }
    [JsonPropertyName("timestamp")]
    public int? Timestamp { get; set; }
    [JsonPropertyName("status")]
    public Status Status { get; set; } = null!;
    public int StatusId { get; set; }
}