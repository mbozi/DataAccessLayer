using DAL.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace DAL;

public class DBSchema
{
    public static MethodResult CreateSchema(string server, string database, string username="AppLogin", string password="letmein" )
    {
        string connectionString = $"Server={server};Database={database};User Id={username};Password={password};TrustServerCertificate=True";
        MethodResult result = VerifyDatabase(server, database, username, password);
        List<string> cmdTextList = new();
        if ( result.Worked==true && result.Code==1 )
        {
            cmdTextList.Add(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Resources", "CreateTables.sql")).Split("--END--")[0]);
            foreach(string cmdText in File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Resources", "CreateStoredProcs.sql")).Split("--END--"))
                cmdTextList.Add(cmdText);
            using SqlConnection connection = new(connectionString);
            try
            {
                connection.Open();
                foreach(string cmdText in cmdTextList)
                {
                    using SqlCommand command = new(cmdText, connection);
                    command.ExecuteNonQuery();
                }
                return new();
            }
            catch (SqlException ex)
            {
                return new(1, ex.Message);
            }
        }
        return result;
    }
    public static MethodResult VerifyDatabase(string server, string database, string username = "AppLogin", string password = "letmein")
    {
        string connectionString = $"Server={server};User Id={username};Password={password};TrustServerCertificate=True";
        string cmdText = $"if Exists(select 1 from master.dbo.sysdatabases where name='{database}') select 'yes' else select 'no'";
        using SqlConnection connection = new(connectionString);
        try
        {
            connection.Open();
            using SqlCommand command = new(cmdText, connection);
            string result = command.ExecuteScalar().ToString()!;
            if (result == "yes")
            { return new(1, "Exists", $"Server={server};Database={database};User Id={username};Password={password};TrustServerCertificate=True"); }
            else
            { return new( 2, "Does Not Exist"); };
        }
        catch (SqlException ex)
        {
            return new(1, ex.Message);
        }
    }
}

