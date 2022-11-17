namespace kyniusBETAPI.Model;

public class BetType
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty!;
    public int? PointValue { get; set; }
}