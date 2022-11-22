using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;

namespace DAL.Model;
public class DBCrud
{
    public string ConnectionString { get; set; }
    public DBCrud(string connectionString)
    {
        ConnectionString = connectionString;
    }

    public DBCrud()
    {
        ConnectionString = "Server=DB01;Database=0001;User Id=AppLogin;Password=letmein;TrustServerCertificate=True";
    }

    private string GenWhereOrderBy(string WHERE, string ORDERBY)
    {
        return WHERE == "" & ORDERBY == "" ? "" : WHERE == "" ? $" ORDER BY {ORDERBY}" : ORDERBY == "" ? $" WHERE {WHERE}" : $" WHERE {WHERE} ORDER BY {ORDERBY}";
    }

    #region "Tenant"
    public int AddTenant(string name, string description)
    {
        try
        {
            using SqlConnection con = new(ConnectionString);
            using SqlCommand cmd = new("dbo.cusp_TenantsINSERT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = description;
            SqlParameter outparm = new("@ID", SqlDbType.Int) { Direction = ParameterDirection.Output };
            cmd.Parameters.Add(outparm);
            con.Open();
            cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ID"].Value;
        }
        catch (SqlException ex)
        {
            throw ex ;
        }
    }


    public Tenant GetTenant(int ID)
    {
        Tenant output = null!;
        try
        {
            
            using SqlConnection con = new(ConnectionString);
            using SqlCommand cmd = new($"SELECT ID,[Name],[Description],DateModified,DateCreated,IsDeleted FROM dbo.Tenants WHERE ID = {ID}", con);
            con.Open();
            using SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                output = new(rdr);
                }
            return output!;
        }
        catch (SqlException ex)
        {
            throw ex;
        }
    }

    public List<Tenant> GetTenants(string WHERE = "", string ORDERBY = "", bool IncludeDeleted = false)
    {
        WHERE = GenWhereOrderBy(WHERE, ORDERBY);
        List<Tenant> output = new();
        try
        {

            using SqlConnection con = new(ConnectionString);
            using SqlCommand cmd = new($"SELECT ID,[Name],[Description],DateModified,DateCreated,IsDeleted FROM dbo.Tenants{WHERE}", con);
            con.Open();
            using SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                output.Add (new(rdr));
            }
            return output!;
        }
        catch (SqlException ex)
        {
            throw ex;
        }
    }
    #endregion

    public int AddEnvironmentType(string name, string description)
    {
        try
        {
            using SqlConnection con = new(ConnectionString);
            using SqlCommand cmd = new("dbo.cusp_EnvironmentTypesINSERT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = description;
            SqlParameter outparm = new("@ID", SqlDbType.Int) { Direction = ParameterDirection.Output };
            cmd.Parameters.Add(outparm);
            con.Open();
            cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ID"].Value;
        }
        catch (SqlException ex)
        {
            throw ex;
        }
    }


    public SQLResult AddApplication(string name, string description)
    {
        try
        {
        using SqlConnection con = new(ConnectionString);
        using SqlCommand cmd = new("dbo.cusp_ApplicationsINSERT", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
        cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = description;
        SqlParameter outparm = new("@ID", SqlDbType.Int) { Direction = ParameterDirection.Output };
        cmd.Parameters.Add(outparm);
        con.Open();
        cmd.ExecuteNonQuery();
        return new((int)cmd.Parameters["@ID"].Value);
        }
        catch (SqlException ex)
        {
            return new(ex.ErrorCode, ex.Message);
        }
    }
    public List<Application> GetApplications(string WHERE = "", string ORDERBY = "", bool IncludeDeleted = false)
    {
        WHERE = GenWhereOrderBy(WHERE, ORDERBY);
        List<Application> output = new();
        try
        {

            using SqlConnection con = new(ConnectionString);
            using SqlCommand cmd = new($"SELECT ID,[Name],[Description],DateModified,DateCreated,IsDeleted FROM dbo.Applications{WHERE}", con);
            con.Open();
            using SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                output.Add(new(rdr));
            }
            return output!;
        }
        catch (SqlException ex)
        {
            throw ex;
        }
    }
}
