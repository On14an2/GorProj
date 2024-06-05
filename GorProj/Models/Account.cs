using System;
using System.Collections.Generic;

namespace GorProj.Models;

public partial class Account
{
    public int IdAccount { get; set; }

    public int? IdEmployee { get; set; }

    public int? IdSchedule { get; set; }

    public int? IdAccountStatus { get; set; }

    public int? IdRole { get; set; }

    public string? LoginAccount { get; set; }

    public string? PasswordAccount { get; set; }

    public DateOnly? PeriodValidityFrom { get; set; }

    public DateOnly? PeriodValidityBy { get; set; }

    public DateOnly? LastLogin { get; set; }

    public DateOnly? LastPasswordChange { get; set; }

    public virtual AccountStatus? IdAccountStatusNavigation { get; set; }

    public virtual Employee? IdEmployeeNavigation { get; set; }

    public virtual Role? IdRoleNavigation { get; set; }

    public virtual Schedule? IdScheduleNavigation { get; set; }
}
