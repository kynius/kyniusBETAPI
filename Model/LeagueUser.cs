using kyniusBETAPI.AbstractModel;

namespace kyniusBETAPI.Model;

public class LeagueUser
{
    public int Id { get; set; }
    public User User { get; set; } = new User();
    public string UserId { get; set; } = String.Empty!;
    public League League { get; set; } = new League();
    public int LeagueId { get; set; }
    public string Role { get; set; } = String.Empty!;
}