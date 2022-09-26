using System.ComponentModel.DataAnnotations;
using kyniusBETAPI.Model;

namespace kyniusBETAPI.Data.DTO;

public class LeagueDTO
{
    [Required(ErrorMessage = "League name is required")]
    public string Name { get; set; } = string.Empty!;
    public string UserName { get; set; } = string.Empty!;
}