using System;
using System.Collections.Generic;

namespace GorProj.Models;

public partial class System
{
    public int IdSystem { get; set; }

    public int? IdRole { get; set; }

    public string? NameSystem { get; set; }

    public virtual Role? IdRoleNavigation { get; set; }
}
