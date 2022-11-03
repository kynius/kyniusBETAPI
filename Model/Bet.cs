using kyniusBETAPI.Data.DTO;

namespace kyniusBETAPI.Model;

public class Bet
{
    public int Id { get; set; }
    public virtual LeagueBet LeagueBet { get; set; }
    public int LeagueBetId { get; set; }
    public virtual User User { get; set; }
    public string? UserId { get; set; }
    public string Value { get; set; } = String.Empty!;
    public bool? IsCorrect { get; set; }
    public DateTime DateTime { get; set; } = DateTime.Now;

    public Bet()
    {
        
    }
    public Bet(BetDTO b)
    {
        LeagueBetId = b.LeagueBetId;
        Value = b.Value;
    }
}