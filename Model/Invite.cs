using kyniusBETAPI.Data.DTO;

namespace kyniusBETAPI.Model;

public class Invite
{
    public int Id { get; set; }
    public User? InvitingUser { get; set; } 
    public string? InvitingUserId { get; set; } 
    public User? InvitedUser { get; set; }
    public string? InvitedUserId { get; set; } 
    public string Status { get; set; } = String.Empty!;
    public League? League { get; set; } 
    public int? LeagueId { get; set; }
    public DateTime DateCreated { get; set; }

    public Invite()
    {
        
    }
    public Invite(InviteDTO i)
    {
        InvitingUserId = i.InvitingUserId;
        InvitedUserId = i.InvitedUserId;
        Status = i.Status;
        LeagueId = i.LeagueId;
        DateCreated = i.DateCreated;
    }
}