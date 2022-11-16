using System.Data.SqlClient;
using System.Data;
using System;

namespace DAL.Model;
public class DBCrud
{
    public string ConnectionString { get; set; }
    public DBCrud(string connectionString)
    {
        ConnectionString = connectionString;
    }
   

    public int AddTenant(string name, string description)
    {
        using SqlConnection con = new(ConnectionString);
        using SqlCommand cmd = new("dbo.cusp_TenantsINSERT", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
        cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = description;
        SqlParameter outparm = new("@ID", SqlDbType.Int);
        outparm.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(outparm);
        con.Open();
        cmd.ExecuteNonQuery();
        return (int)cmd.Parameters["@ID"].Value;
    }
}
