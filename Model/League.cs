using kyniusBETAPI.Data.DTO;

namespace kyniusBETAPI.Model;

public class League
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty!;
    public virtual List<LeagueUser> LeagueUser { get; set; } = null!;

    public League(LeagueDTO l)
    {
        Name = l.Name;
    }
    public League()
    {
        
    }
}