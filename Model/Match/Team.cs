using System.Text.Json.Serialization;

namespace kyniusBETAPI.Model.Match;

public class Team
{
    [JsonIgnore]
    public int Id { get; set; }
    [JsonPropertyName("id")] 
    public int ApiId { get; set; }
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    [JsonPropertyName("logo")]
    public string? Logo { get; set; }
}