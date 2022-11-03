using kyniusBETAPI.Data.DTO;

namespace kyniusBETAPI.Model;

public class LeagueBet
{
    public int Id { get; set; }
    public virtual Match.Match Match { get; set; }
    public int? MatchId { get; set; }
    public virtual BetType BetType { get; set; }
    public int? BetTypeId { get; set; }
    public virtual League League { get; set; }
    public int? LeagueId { get; set; }
    public virtual User User { get; set; }
    public string? UserId { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public DateTime DateToBet { get; set; }

    public LeagueBet()
    {
        
    }
    public LeagueBet(LeagueBetDTO l)
    {
        MatchId = l.MatchId;
        BetTypeId = l.BetTypeId;
    }
}