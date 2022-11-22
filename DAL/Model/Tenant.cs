using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL.Model;

public class Tenant : BaseDBSchema
{
    public Tenant(int iD, string name, string? description, DateTime dateModified, DateTime dateCreated, string isDeleted) : base(iD, name, description, dateModified, dateCreated, isDeleted)
    {
        ID= iD;
        Name= name;
        Description= description;
        DateModified= dateModified;
        DateCreated= dateCreated;
        IsDeleted= isDeleted;
    }
    public Tenant(SqlDataReader rdr) : base(rdr)
    {
        ID = rdr.GetInt32(0);
        Name = rdr.GetString(1);
        Description = rdr.GetString(2);
        DateModified = rdr.GetDateTime(3);
        DateCreated = rdr.GetDateTime(4);
        IsDeleted = rdr.GetValue(5).ToString() ?? "0";
    }
}