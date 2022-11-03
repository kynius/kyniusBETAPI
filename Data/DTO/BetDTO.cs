using System.ComponentModel.DataAnnotations;
using kyniusBETAPI.Model;

namespace kyniusBETAPI.Data.DTO;

public class BetDTO
{
    [Required(ErrorMessage = "Bet type is required")]
    public int LeagueBetId { get; set; }
    [Required(ErrorMessage = "Value is required")]
    public string Value { get; set; } = String.Empty!;
    [Required(ErrorMessage = "Date To Bet is required")]
    public DateTime DateToBet { get; set; }
}