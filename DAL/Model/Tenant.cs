using System.Collections.Generic;

namespace DAL.Model;

public class Tenant : BaseDBSchema
{
    public ICollection<EnvironmentType> EnvironmentTypes { get; set; } = null!;
}