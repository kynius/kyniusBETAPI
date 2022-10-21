using kyniusBETAPI.Data.Enums;
using kyniusBETAPI.Model;
using kyniusBETAPI.Model.Match;

namespace kyniusBETAPI.Data.ViewModel;

public class BetViewModel
{
    public Team HomeTeam { get; set; }
    public Team AwayTeam { get; set; }
    public BetTypesEnum BetType { get; set; }
    public string Value { get; set; }
    public DateTime DateTime { get; set; }
    public BetViewModel(Bet bet)
    {
        HomeTeam = bet.Match.Home;
        AwayTeam = bet.Match.Away;
        BetType = bet.BetType;
        Value = bet.Value;
        DateTime = bet.DateTime;
    }
}