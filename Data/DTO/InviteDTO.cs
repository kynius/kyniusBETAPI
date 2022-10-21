namespace kyniusBETAPI.Data.DTO;

public class InviteDTO
{
    public string? InvitingUserId { get; set; }
    public string? InvitedUserId { get; set; }
    public int LeagueId { get; set; }
    public string Status { get; set; } = String.Empty!;
    public DateTime DateCreated { get; set; } = DateTime.Now;
}