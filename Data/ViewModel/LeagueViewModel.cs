using kyniusBETAPI.Model;

namespace kyniusBETAPI.Data.ViewModel;

public class LeagueViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<LeagueUserViewModel> LeagueUsers { get; set; } = new List<LeagueUserViewModel>();
    public LeagueViewModel(League league)
    {
        Id = league.Id;
        Name = league.Name;
    }
}