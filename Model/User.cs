using Microsoft.AspNetCore.Identity;

namespace kyniusBETAPI.Model;

public class User : IdentityUser
{
    public string FirstName { get; set; } = String.Empty!;
    public string LastName { get; set; } = String.Empty!;
    public string AvatarImageUrl { get; set; } = String.Empty!;
}