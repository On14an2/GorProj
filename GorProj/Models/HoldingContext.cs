using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GorProj.Models;

public partial class HoldingContext : DbContext
{
    public HoldingContext()
    {
    }

    public HoldingContext(DbContextOptions<HoldingContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountStatus> AccountStatuses { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeStatus> EmployeeStatuses { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<System> Systems { get; set; }

    public virtual DbSet<Weekday> Weekdays { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HOLDING;Integrated Security=True;Connect Timeout=60;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.IdAccount).HasName("PK__ACCOUNTS__95DBD46216FA77F2");

            entity.ToTable("ACCOUNTS");

            entity.Property(e => e.IdAccount).HasColumnName("ID_ACCOUNT");
            entity.Property(e => e.IdAccountStatus).HasColumnName("ID_ACCOUNT_STATUS");
            entity.Property(e => e.IdEmployee).HasColumnName("ID_EMPLOYEE");
            entity.Property(e => e.IdRole).HasColumnName("ID_ROLE");
            entity.Property(e => e.IdSchedule).HasColumnName("ID_SCHEDULE");
            entity.Property(e => e.LastLogin).HasColumnName("LAST_LOGIN");
            entity.Property(e => e.LastPasswordChange).HasColumnName("LAST_PASSWORD_CHANGE");
            entity.Property(e => e.LoginAccount)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("NEW_LOGIN")
                .HasColumnName("LOGIN_ACCOUNT");
            entity.Property(e => e.PasswordAccount)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("NEW_PASSWORD")
                .HasColumnName("PASSWORD_ACCOUNT");
            entity.Property(e => e.PeriodValidityBy).HasColumnName("PERIOD_VALIDITY_BY");
            entity.Property(e => e.PeriodValidityFrom).HasColumnName("PERIOD_VALIDITY_FROM");

            entity.HasOne(d => d.IdAccountStatusNavigation).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.IdAccountStatus)
                .HasConstraintName("FK_ACCOUNT_STATUSES_ACCOUNTS");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.IdEmployee)
                .HasConstraintName("FK_EMPLOYEES_ACCOUNTS");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("FK_ROLES_ACCOUNTS");

            entity.HasOne(d => d.IdScheduleNavigation).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.IdSchedule)
                .HasConstraintName("FK_SCHEDULES_ACCOUNTS");
        });

        modelBuilder.Entity<AccountStatus>(entity =>
        {
            entity.HasKey(e => e.IdAccountStatus).HasName("PK__ACCOUNT___696772E9C6D46A06");

            entity.ToTable("ACCOUNT_STATUSES");

            entity.Property(e => e.IdAccountStatus).HasColumnName("ID_ACCOUNT_STATUS");
            entity.Property(e => e.NameAccountStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("NEW_ACCOUNT_STATUS")
                .HasColumnName("NAME_ACCOUNT_STATUS");
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.IdAppointment).HasName("PK__APPOINTM__983A3258DFFCFC1A");

            entity.ToTable("APPOINTMENTS");

            entity.Property(e => e.IdAppointment).HasColumnName("ID_APPOINTMENT");
            entity.Property(e => e.IdPosition).HasColumnName("ID_POSITION");
            entity.Property(e => e.PeriodEmploymentBy).HasColumnName("PERIOD_EMPLOYMENT_BY");
            entity.Property(e => e.PeriodEmploymentFrom).HasColumnName("PERIOD_EMPLOYMENT_FROM");
            entity.Property(e => e.PeriodNonPerformanceDutiesBy).HasColumnName("PERIOD_NON_PERFORMANCE_DUTIES_BY");
            entity.Property(e => e.PeriodNonPerformanceDutiesFrom).HasColumnName("PERIOD_NON_PERFORMANCE_DUTIES_FROM");

            entity.HasOne(d => d.IdPositionNavigation).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.IdPosition)
                .HasConstraintName("FK_POSITIONS_APPOINTMENTS");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.IdDepartment).HasName("PK__DEPARTME__F98EBB3DC9203656");

            entity.ToTable("DEPARTMENTS");

            entity.Property(e => e.IdDepartment).HasColumnName("ID_DEPARTMENT");
            entity.Property(e => e.IdOrganization).HasColumnName("ID_ORGANIZATION");
            entity.Property(e => e.NameDepartment)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("NEW_DEPARTMENT")
                .HasColumnName("NAME_DEPARTMENT");

            entity.HasOne(d => d.IdOrganizationNavigation).WithMany(p => p.Departments)
                .HasForeignKey(d => d.IdOrganization)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORGANIZATIONS_DEPARTMENTS");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.IdEmployee).HasName("PK__EMPLOYEE__FFDDC303180D7F18");

            entity.ToTable("EMPLOYEES");

            entity.Property(e => e.IdEmployee).HasColumnName("ID_EMPLOYEE");
            entity.Property(e => e.BirthdayEmployee).HasColumnName("BIRTHDAY_EMPLOYEE");
            entity.Property(e => e.FamilyEmployee)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("NEW_FAMILY")
                .HasColumnName("FAMILY_EMPLOYEE");
            entity.Property(e => e.GenderEmployee)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("MAN")
                .HasColumnName("GENDER_EMPLOYEE");
            entity.Property(e => e.IdAppointment).HasColumnName("ID_APPOINTMENT");
            entity.Property(e => e.IdEmployeeStatus).HasColumnName("ID_EMPLOYEE_STATUS");
            entity.Property(e => e.NameEmployee)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("NEW_NAME")
                .HasColumnName("NAME_EMPLOYEE");
            entity.Property(e => e.PatronymicEmployee)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("NEW_PATRONYMIC")
                .HasColumnName("PATRONYMIC_EMPLOYEE");

            entity.HasOne(d => d.IdAppointmentNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdAppointment)
                .HasConstraintName("FK_APPOINTMENTS_EMPLOYEES");

            entity.HasOne(d => d.IdEmployeeStatusNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdEmployeeStatus)
                .HasConstraintName("FK_EMPLOYEE_STATUSES_EMPLOYEES");
        });

        modelBuilder.Entity<EmployeeStatus>(entity =>
        {
            entity.HasKey(e => e.IdEmployeeStatus).HasName("PK__EMPLOYEE__3EAEE30AD3004872");

            entity.ToTable("EMPLOYEE_STATUSES");

            entity.Property(e => e.IdEmployeeStatus).HasColumnName("ID_EMPLOYEE_STATUS");
            entity.Property(e => e.NameEmployeeStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("NEW_EMPLOYEE_STATUS")
                .HasColumnName("NAME_EMPLOYEE_STATUS");
        });

        modelBuilder.Entity<Organization>(entity =>
        {
            entity.HasKey(e => e.IdOrganization).HasName("PK__ORGANIZA__41E5C4CB66BF3ABC");

            entity.ToTable("ORGANIZATIONS");

            entity.Property(e => e.IdOrganization).HasColumnName("ID_ORGANIZATION");
            entity.Property(e => e.NameOrganization)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("NEW_ORGANIZATION")
                .HasColumnName("NAME_ORGANIZATION");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.IdPosition).HasName("PK__POSITION__07B34A27BEC4C277");

            entity.ToTable("POSITIONS");

            entity.Property(e => e.IdPosition).HasColumnName("ID_POSITION");
            entity.Property(e => e.IdDepartment).HasColumnName("ID_DEPARTMENT");
            entity.Property(e => e.NamePosition)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("NEW_POSITION")
                .HasColumnName("NAME_POSITION");

            entity.HasOne(d => d.IdDepartmentNavigation).WithMany(p => p.Positions)
                .HasForeignKey(d => d.IdDepartment)
                .HasConstraintName("FK_DEPARTMENTS_POSITIONS");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("PK__ROLES__C7D0F657AF5D7719");

            entity.ToTable("ROLES");

            entity.Property(e => e.IdRole).HasColumnName("ID_ROLE");
            entity.Property(e => e.NameRole)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("NEW_ROLE")
                .HasColumnName("NAME_ROLE");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.IdSchedule).HasName("PK__SCHEDULE__AD4642E4C61F1B3D");

            entity.ToTable("SCHEDULES");

            entity.Property(e => e.IdSchedule).HasColumnName("ID_SCHEDULE");
            entity.Property(e => e.IdDays).HasColumnName("ID_DAYS");
            entity.Property(e => e.TimeFrom).HasColumnName("TIME_FROM");
            entity.Property(e => e.TimeTo).HasColumnName("TIME_TO");

            entity.HasOne(d => d.IdDaysNavigation).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.IdDays)
                .HasConstraintName("FK_DAYS_SCHEDULES");
        });

        modelBuilder.Entity<System>(entity =>
        {
            entity.HasKey(e => e.IdSystem).HasName("PK__SYSTEMS__B5C5CF5BFDFACBC8");

            entity.ToTable("SYSTEMS");

            entity.Property(e => e.IdSystem).HasColumnName("ID_SYSTEM");
            entity.Property(e => e.IdRole).HasColumnName("ID_ROLE");
            entity.Property(e => e.NameSystem)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("NEW_SYSTEM")
                .HasColumnName("NAME_SYSTEM");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Systems)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("FK_SYSTEMS_ROLES");
        });

        modelBuilder.Entity<Weekday>(entity =>
        {
            entity.HasKey(e => e.IdWeekday).HasName("PK__WEEKDAYS__681DD5D1D6AF2679");

            entity.ToTable("WEEKDAYS");

            entity.Property(e => e.IdWeekday).HasColumnName("ID_WEEKDAY");
            entity.Property(e => e.NameWeekday)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME_WEEKDAY");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
