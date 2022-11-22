using System.Data.SqlClient;

namespace DAL.Model;

public class EnvironmentType : BaseDBSchema
{

    public EnvironmentType(SqlDataReader rdr) : base(rdr)
    {
        ID = rdr.GetInt32(0);
        Name = rdr.GetString(1);
        Description = rdr.GetString(2);
        DateModified = rdr.GetDateTime(3);
        DateCreated = rdr.GetDateTime(4);
        IsDeleted = rdr.GetChar(5).ToString();
    }
}
