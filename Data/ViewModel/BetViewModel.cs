using kyniusBETAPI.Model;
using kyniusBETAPI.Model.Match;

namespace kyniusBETAPI.Data.ViewModel;

public class BetViewModel
{
    public int Id { get; set; }
    public Team HomeTeam { get; set; }
    public Team AwayTeam { get; set; }
    public BetType BetType { get; set; }
    public string? Value { get; set; }
    public DateTime DateTime { get; set; }
    public DateTime DateToBet { get; set; }
    public bool? IsCorrect { get; set; }
    public BetViewModel(Bet bet)
    {
        Value = bet.Value;
        DateTime = bet.DateTime;
        IsCorrect = bet.IsCorrect;
        HomeTeam = bet.LeagueBet.Match.Home;
        AwayTeam = bet.LeagueBet.Match.Away;
        BetType = bet.LeagueBet.BetType;
        DateToBet = bet.LeagueBet.DateToBet;
    }
    public BetViewModel()
    {
        
    }
}