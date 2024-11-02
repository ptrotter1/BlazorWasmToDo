namespace BlazorWasmToDo;

public class Error
{
    public string Code { get; set; } = string.Empty;

    public string CodeType { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;
    
    public override string ToString() => $"{Code}: {Message}";
    
    public static implicit operator string(Error error) => error.ToString();
}