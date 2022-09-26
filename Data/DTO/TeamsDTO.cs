using System.Text.Json.Serialization;
using kyniusBETAPI.Model.Match;

namespace kyniusBETAPI.Data.DTO;

public class TeamsDTO
{
    [JsonPropertyName("home")]
    public Team Home { get; set; } = null!;
    [JsonPropertyName("away")]
    public Team Away { get; set; } = null!;
}