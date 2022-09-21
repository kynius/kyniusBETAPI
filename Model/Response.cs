namespace kyniusBETAPI.Model;

public class Response
{
    public int? Error { get; set; }
    public bool IsSucceeded { get; set; }
    public string Message { get; set; } = String.Empty!;
}