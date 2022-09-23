using System.Text.Json.Serialization;
using kyniusBETAPI.Data.DTO;

namespace kyniusBETAPI.Model.Match;

public class Match
{
    public int Id { get; set; }
    public int ApiId { get; set; }
    public string? Referee { get; set; }
    public DateTime? Date { get; set; }
    public int? Timestamp { get; set; }
    public Status Status { get; set; } = null!;
    public int? StatusId { get; set; }
    public FootballLeague FootballLeague { get; set; }= null!;
    public int? FootballLeagueId { get; set; }
    public Team Home { get; set; }= null!;
    public int? HomeId { get; set; }
    public Team Away { get; set; }= null!;
    public int? AwayId { get; set; }
    public Goals Goals { get; set; }= null!;
    public int? GoalsId { get; set; }
    public Score Score { get; set; }= null!;
    public int? ScoreId { get; set; }
    public Match(MatchDTO m)
    {
        ApiId = m.Fixture.Id;
        Referee = m.Fixture.Referee;
        Date = m.Fixture.Date;
        Timestamp = m.Fixture.Timestamp;
        Status = m.Fixture.Status;
        StatusId = m.Fixture.StatusId;
        FootballLeague = m.FootballLeague;
        FootballLeagueId = m.FootballLeagueId;
        Home = m.Teams.Home;
        HomeId = m.Teams.Home.Id;
        Away = m.Teams.Away;
        AwayId = m.Teams.Away.Id;
        Goals = m.Goals;
        GoalsId = m.Goals.Id;
        Score = m.Score;
        ScoreId = m.Score.Id;
    }
    public Match()
    {
        
    }
}