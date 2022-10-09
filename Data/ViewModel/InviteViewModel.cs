using kyniusBETAPI.Model;

namespace kyniusBETAPI.Data.ViewModel;

public class InviteViewModel
{
    public int Id { get; set; }
    public string? InvitedUserName { get; set; }
    public string? InvitingUserName { get; set; }
    public string? LeagueName { get; set; }
    public DateTime DateCreated { get; set; }
    public int LeagueId { get; set; }

    public InviteViewModel(Invite invite)
    {
        Id = invite.Id;
        InvitedUserName = invite.InvitedUser?.UserName;
        InvitingUserName = invite.InvitingUser?.UserName;
        LeagueName = invite.League?.Name;
        DateCreated = invite.DateCreated;
        LeagueId = invite.League.Id;
    }
}