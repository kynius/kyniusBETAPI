using System.ComponentModel.DataAnnotations;

namespace kyniusBETAPI.Data.DTO;

public class UserLoginDTO
{
    [Required(ErrorMessage = "Login is required")]
    public string UserName { get; set; } = string.Empty!;
    [Required(ErrorMessage = "Login is required")]
    public string Password { get; set; } = string.Empty!;
}