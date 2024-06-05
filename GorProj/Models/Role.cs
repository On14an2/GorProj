using System;
using System.Collections.Generic;

namespace GorProj.Models;

public partial class Role
{
    public int IdRole { get; set; }

    public string? NameRole { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual ICollection<System> Systems { get; set; } = new List<System>();
}
