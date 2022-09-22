namespace kyniusBETAPI.AbstractModel;

public class Response
{
    public int? ResponseNumber { get; set; } = null;
    public bool IsSucceeded { get; set; }
    public string Message { get; set; } = String.Empty!;
    public string? Token { get; set; } = null;
}