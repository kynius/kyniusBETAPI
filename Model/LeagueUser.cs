namespace kyniusBETAPI.Model;

public class LeagueUser
{
    public int Id { get; set; }
    public User User { get; set; } = null!;
    public string UserId { get; set; } = String.Empty!;
    public League League { get; set; } = null!;
    public int LeagueId { get; set; }
}