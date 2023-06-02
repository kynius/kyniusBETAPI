namespace kyniusBETAPI.NoSQLModel;

public class Response
{
    public int? ResponseNumber { get; set; } = null;
    public bool IsSucceeded { get; set; }
    public object Message { get; set; } = null!;
    public string? Token { get; set; } = null;
}