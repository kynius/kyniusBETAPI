namespace kyniusBETAPI.Model;

public class Match
{
    public int Id { get; set; }
    public DateTime MatchDate { get; set; }
    public FootballLeague? League { get; set; } = null!;
    public int LeagueId { get; set; }
    public Team? HomeTeam { get; set; } = null!;
    public int? HomeTeamId { get; set; }
    public Team? AwayTeam { get; set; } = null!;
    public int? AwayTeamId { get; set; }
    public bool IsHomeWinner { get; set; }
    public bool IsAwayWinner { get; set; }
    public int HomeTeamHalf { get; set; }
    public int AwayTeamHalf { get; set; }
    public int HomeTeamFull { get; set; }
    public int AwayTeamFull { get; set; }
    public int? HomeTeamExtra { get; set; }
    public int? AwayTeamExtra { get; set; }
    public int? HomeTeamPenalty { get; set; }
    public int? AwayTeamPenalty { get; set; }
    public string StadiumName { get; set; } = String.Empty!;
    public string StatusLong { get; set; } = String.Empty!;
    public string StatusShort { get; set; } = String.Empty!;
    public int Time { get; set; }
}