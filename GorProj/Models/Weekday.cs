using System;
using System.Collections.Generic;

namespace GorProj.Models;

public partial class Weekday
{
    public int IdWeekday { get; set; }

    public string? NameWeekday { get; set; }

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
