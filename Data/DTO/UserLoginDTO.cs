using System.ComponentModel.DataAnnotations;

namespace kyniusBETAPI.Data.DTO;

public class UserLoginDTO
{
    [Required(ErrorMessage = "Login or password is incorrect")]
    public string UserName { get; set; } = string.Empty!;
    [Required(ErrorMessage = "Login or password is incorrect")]
    public string Password { get; set; } = string.Empty!;
}