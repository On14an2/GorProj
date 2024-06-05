using System;
using System.Collections.Generic;

namespace GorProj.Models;

public partial class Employee
{
    public int IdEmployee { get; set; }

    public int? IdAppointment { get; set; }

    public int? IdEmployeeStatus { get; set; }

    public string? NameEmployee { get; set; }

    public string? FamilyEmployee { get; set; }

    public string? PatronymicEmployee { get; set; }

    public string? GenderEmployee { get; set; }

    public DateOnly? BirthdayEmployee { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual Appointment? IdAppointmentNavigation { get; set; }

    public virtual EmployeeStatus? IdEmployeeStatusNavigation { get; set; }
}
