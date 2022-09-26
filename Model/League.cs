using kyniusBETAPI.Data.DTO;

namespace kyniusBETAPI.Model;

public class League
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty!;
    public List<LeagueUser> LeagueUser { get; set; } = new List<LeagueUser>();

    public League(LeagueDTO l)
    {
        Name = l.Name;
    }

    public League()
    {
        
    }
}