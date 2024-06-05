using System;
using System.Collections.Generic;

namespace GorProj.Models;

public partial class Department
{
    public int IdDepartment { get; set; }

    public int IdOrganization { get; set; }

    public string? NameDepartment { get; set; }

    public virtual Organization IdOrganizationNavigation { get; set; } = null!;

    public virtual ICollection<Position> Positions { get; set; } = new List<Position>();
}
