using kyniusBETAPI.Data.DTO;
using kyniusBETAPI.Data.Enums;

namespace kyniusBETAPI.Model;

public class Bet
{
    public int Id { get; set; }
    public virtual LeagueUser LeagueUser { get; set; }
    public virtual int LeagueUserId { get; set; }
    public BetTypesEnum BetType { get; set; }
    public virtual Match.Match Match { get; set; }
    public int? MatchId { get; set; }
    public string Value { get; set; } = String.Empty!;
    public bool? IsCorrect { get; set; }
    public DateTime DateTime { get; set; } = DateTime.Now;

    public Bet()
    {
        
    }
    public Bet(BetDTO b)
    {
        Value = b.Value;
        BetType = b.BetType;
        MatchId = b.MatchId;
    }
}