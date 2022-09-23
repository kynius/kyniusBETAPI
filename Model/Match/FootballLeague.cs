using System.Text.Json.Serialization;

namespace kyniusBETAPI.Model.Match;

public class FootballLeague
{
    [JsonIgnore]
    public int Id { get; set; }
    [JsonPropertyName("id")] 
    public int ApiId { get; set; }
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    [JsonPropertyName("country")]
    public string? Country { get; set; }
    [JsonPropertyName("logo")]
    public string? Logo { get; set; }
    [JsonPropertyName("flag")]
    public string? Flag { get; set; }
}