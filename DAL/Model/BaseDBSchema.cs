using System;

namespace DAL.Model;

public class BaseDBSchema
{
    public int ID { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime DateModified { get; set; } = DateTime.Now;
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public string IsDeleted { get; set; } = "0";
}
