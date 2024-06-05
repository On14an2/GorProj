using System;
using System.Collections.Generic;

namespace GorProj.Models;

public partial class Position
{
    public int IdPosition { get; set; }

    public int? IdDepartment { get; set; }

    public string? NamePosition { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Department? IdDepartmentNavigation { get; set; }
}
