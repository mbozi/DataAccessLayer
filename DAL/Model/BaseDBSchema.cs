using System;
using System.Data.SqlClient;

namespace DAL.Model;

public abstract class BaseDBSchema
{
    public BaseDBSchema(int iD, string name, string? description, DateTime dateModified, DateTime dateCreated, string isDeleted)
    {
        ID = iD;
        Name = name;
        Description = description;
        DateModified = dateModified;
        DateCreated = dateCreated;
        IsDeleted = isDeleted;
    }

    public BaseDBSchema(SqlDataReader rdr) { }

    public int ID { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime DateModified { get; set; } = DateTime.Now;
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public string IsDeleted { get; set; } = "0";
}
