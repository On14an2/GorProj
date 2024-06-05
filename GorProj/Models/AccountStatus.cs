using System;
using System.Collections.Generic;

namespace GorProj.Models;

public partial class AccountStatus
{
    public int IdAccountStatus { get; set; }

    public string? NameAccountStatus { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
