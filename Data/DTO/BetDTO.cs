using System.ComponentModel.DataAnnotations;
using kyniusBETAPI.Data.Enums;

namespace kyniusBETAPI.Data.DTO;

public class BetDTO
{
    [Required(ErrorMessage = "Bet type is required")]
    public BetTypesEnum BetType { get; set; }
    [Required(ErrorMessage = "MatchId is required")]
    public int MatchId { get; set; }
    [Required(ErrorMessage = "Value is required")]
    public string Value { get; set; } = String.Empty!;
}