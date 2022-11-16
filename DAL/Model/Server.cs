namespace DAL.Model;

public class Server : BaseDBSchema
{
    public ServerRole Role { get; set; } = null!;
}
