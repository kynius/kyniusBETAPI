using kyniusBETAPI.NoSQLModel;

namespace kyniusBETAPI.Model;

public class LeagueUser
{
    public int Id { get; set; }
    public virtual User User { get; set; } = null!;
    public string UserId { get; set; } = String.Empty!;
    public virtual League League { get; set; } = null!;
    public int LeagueId { get; set; }
    public string Role { get; set; } = String.Empty!;
    public int Points { get; set; }
}