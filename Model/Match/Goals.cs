using System.Text.Json.Serialization;

namespace kyniusBETAPI.Model.Match;

public class Goals
{
    [JsonIgnore]
    public int Id { get; set; }
    [JsonPropertyName("home")]
    public int? Home { get; set; }
    [JsonPropertyName("away")]
    public int? Away { get; set; }
}