using System;
using System.Collections.Generic;

namespace GorProj.Models;

public partial class EmployeeStatus
{
    public int IdEmployeeStatus { get; set; }

    public string? NameEmployeeStatus { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
