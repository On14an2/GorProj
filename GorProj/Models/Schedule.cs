using System;
using System.Collections.Generic;

namespace GorProj.Models;

public partial class Schedule
{
    public int IdSchedule { get; set; }

    public int? IdDays { get; set; }

    public TimeOnly? TimeFrom { get; set; }

    public TimeOnly? TimeTo { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual Weekday? IdDaysNavigation { get; set; }
}
