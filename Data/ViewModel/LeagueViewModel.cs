using kyniusBETAPI.Model;

namespace kyniusBETAPI.Data.ViewModel;

public class LeagueViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } 
    public string UserId { get; set; } 
    public string UserRole { get; set; } 

    public LeagueViewModel(League l)
    {
        Id = l.Id;
        Name = l.Name;
        UserId = l.LeagueUser.FirstOrDefault().UserId;
        UserRole = l.LeagueUser.FirstOrDefault().Role;
    }
}