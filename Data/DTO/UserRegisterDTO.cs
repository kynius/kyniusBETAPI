using System.ComponentModel.DataAnnotations;

namespace kyniusBETAPI.Data.DTO;

public class UserRegisterDTO
{
    [Required(ErrorMessage = "Username is required")]
    public string UserName { get; set; } = string.Empty!;
    [Required(ErrorMessage = "Email is required")]
    [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "E-mail is not valid")]
    public string Email { get; set; } = string.Empty!;
    [Required (ErrorMessage = "First Name is required")] 
    public string FirstName { get; set; } = string.Empty!;
    [Required (ErrorMessage = "Last Name is required")] 
    public string LastName { get; set; } = string.Empty!;
    [Required (ErrorMessage = "Password is required")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$", ErrorMessage = "Password must have: - min. 8 letters - min. 1 capital letter - min. 1 small letter - min. 1 number - min. 1 symbol")]
    public string Password { get; set; } = string.Empty!;
}