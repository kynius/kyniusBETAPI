namespace kyniusBETAPI.Model;

public class FootballLeague
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty!;
    public string Country { get; set; } = String.Empty!;
    public string Logo { get; set; } = String.Empty!;
    public string Flag { get; set; } = String.Empty!;
}