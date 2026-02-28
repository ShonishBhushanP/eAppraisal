using System;
using System.Collections.Generic;

namespace eAppraisal.Domain.Entities;

public partial class UserLogin
{
    public long UserId { get; set; }

    public long EmployeeId { get; set; }

    public string? Username { get; set; }

    public string? PasswordHash { get; set; }

    public string? Role { get; set; }

    public int? FailedAttempts { get; set; }

    public bool? IsLocked { get; set; }

    public DateTime? LastLogin { get; set; }

    public string? AddedBy { get; set; }

    public string? ModifyBy { get; set; }

    public DateTime? AddedAt { get; set; }

    public DateTime? ModifyAt { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;
}
