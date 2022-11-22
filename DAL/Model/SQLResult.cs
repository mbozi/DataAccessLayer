namespace DAL.Model;

public class SQLResult
{
    public SQLResult(int id)
    {
        ID = id;
        ErrorCode = 0;
    }

    public SQLResult(int errorcode, string? description)
    {
        ID = 0;
        ErrorCode=errorcode;
        Description = description;
    }

    public int ID { get; set; }
    public int ErrorCode { get; set; }
    public string? Description { get; set; }
}
