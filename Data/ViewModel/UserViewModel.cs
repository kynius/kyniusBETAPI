using kyniusBETAPI.Model;

namespace kyniusBETAPI.Data.ViewModel;

public class UserViewModel
{
    public string Id { get; set; } 
    public string UserName { get; set; } 
    public string FirstName { get; set; } 
    public string LastName { get; set; } 
    public List<LeagueUserViewModel> LeagueUser { get; set; } = new List<LeagueUserViewModel>();

    public UserViewModel(User user)
    {
        Id = user.Id;
        UserName = user.UserName;
        FirstName = user.FirstName;
        LastName = user.LastName;
    }
}