using System.Text.Json.Serialization;
using kyniusBETAPI.Model.Match;

namespace kyniusBETAPI.Data.DTO;

public class MatchDTO
{
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("fixture")]
        public FixtureDTO Fixture { get; set; } = null!;
        public int FixtureId { get; set; }
        [JsonPropertyName("league")]
        public FootballLeague FootballLeague { get; set; } = null!;
        public int FootballLeagueId { get; set; }
        [JsonPropertyName("teams")]
        public TeamsDTO Teams { get; set; } = null!;
        [JsonPropertyName("goals")]
        public Goals Goals { get; set; } = null!;
        public int GoalsId { get; set; }
        [JsonPropertyName("score")]
        public Score Score { get; set; } = null!;
        public int ScoreId { get; set; }
}
