namespace OneOf;

public class Err(string message, int code)
{
    public string Message { get;} = message;
    public int Code { get; } = code;
}