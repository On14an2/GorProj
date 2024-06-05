using System;
using System.Collections.Generic;

namespace GorProj.Models;

public partial class Appointment
{
    public int IdAppointment { get; set; }

    public int? IdPosition { get; set; }

    public DateOnly? PeriodEmploymentFrom { get; set; }

    public DateOnly? PeriodEmploymentBy { get; set; }

    public DateOnly? PeriodNonPerformanceDutiesFrom { get; set; }

    public DateOnly? PeriodNonPerformanceDutiesBy { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual Position? IdPositionNavigation { get; set; }
}
