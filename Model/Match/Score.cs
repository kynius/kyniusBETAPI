using System.Text.Json.Serialization;

namespace kyniusBETAPI.Model.Match;

public class Score
{
    [JsonIgnore]
    public int Id { get; set; }
    [JsonPropertyName("halftime")]
    public Goals Halftime { get; set; } = null!;
    public int? HalftimeId { get; set; }
    [JsonPropertyName("fulltime")]
    public Goals Fulltime { get; set; } = null!;
    public int? FulltimeId { get; set; }
    [JsonPropertyName("extratime")]
    public Goals Extratime { get; set; } = null!;
    public int? ExtratimeId { get; set; }
    [JsonPropertyName("penalty")]
    public Goals Penalty { get; set; } = null!;
    public int? PenaltyId { get; set; }
    public Goals GoalsInFirsthalf { get; set; } = new Goals();
    public int? GoalsInFirsthalfId { get; set; } 
    public Goals GoalsInSecondhalf { get; set; } = new Goals();
    public int? GoalsInSecondhalfId { get; set; }
    public bool? IsHomeWinnerFirstHalf { get; set; }
    public bool? IsAwayWinnerFirstHalf  { get; set; }
    public bool? IsHomeWinnerSecondHalf { get; set; }
    public bool? IsAwayWinnerSecondHalf  { get; set; }
    public bool? IsHomeWinnerFullMatch { get; set; }
    public bool? IsAwayWinnerFullMatch  { get; set; }
}