using System;
using System.Collections.Generic;

namespace eAppraisal.Domain.Entities;

public partial class Employee
{
    public long EmployeeId { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? PersonalPhone { get; set; }

    public string? Mobile { get; set; }

    public string? Email { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public string? MaritalStatus { get; set; }

    public DateOnly? DateOfJoining { get; set; }

    public string? PassportNo { get; set; }

    public string? Pan { get; set; }

    public int? WorkExperience { get; set; }

    public long? ReportsTo { get; set; }

    public string? Department { get; set; }

    public string? AddedBy { get; set; }

    public string? ModifyBy { get; set; }

    public DateTime? AddedAt { get; set; }

    public DateTime? ModifyAt { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<Appraisal> AppraisalEmployees { get; set; } = new List<Appraisal>();

    public virtual ICollection<Appraisal> AppraisalManagers { get; set; } = new List<Appraisal>();

    public virtual ICollection<Employee> InverseReportsToNavigation { get; set; } = new List<Employee>();

    public virtual Employee? ReportsToNavigation { get; set; }

    public virtual ICollection<UserLogin> UserLogins { get; set; } = new List<UserLogin>();
}
