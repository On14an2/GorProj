using System;
using System.Collections.Generic;

namespace GorProj.Models;

public partial class Organization
{
    public int IdOrganization { get; set; }

    public string? NameOrganization { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
}
