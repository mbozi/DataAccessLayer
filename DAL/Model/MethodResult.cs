namespace DAL.Model;

public class MethodResult
{
    public MethodResult()
    {
        Worked = true;
        Code = 0;
    }

    public MethodResult(int code, string? description, string returnvalue = "")
    {
        Worked = true;
        Code = code;
        Description = description;
        ReturnValue = returnvalue;
    }

    public MethodResult(int code, string? description)
    {
        Worked = false;
        Code = code;
        Description = description;
    }

    public bool Worked { get; set; }
    public int Code { get; set; }
    public string? Description { get; set; }
    public string ReturnValue { get; set; } = string.Empty;
}
