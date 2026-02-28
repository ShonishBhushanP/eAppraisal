using System;
using System.Collections.Generic;

namespace eAppraisal.Domain.Entities;

public partial class Appraisal
{
    public long AppraisalId { get; set; }

    public long EmployeeId { get; set; }

    public long ManagerId { get; set; }

    public long StatusId { get; set; }

    public DateOnly? NextAppraisalDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? AddedBy { get; set; }

    public string? ModifyBy { get; set; }

    public DateTime? AddedAt { get; set; }

    public DateTime? ModifyAt { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<Compensation> Compensations { get; set; } = new List<Compensation>();

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<EmployeeComments> EmployeeComments { get; set; } = new List<EmployeeComments>();

    public virtual Employee Manager { get; set; } = null!;

    public virtual ICollection<ManagerComments> ManagerComments { get; set; } = new List<ManagerComments>();

    public virtual AppraisalStatusMaster Status { get; set; } = null!;
}
