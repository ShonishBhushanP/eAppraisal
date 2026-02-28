using System;
using System.Collections.Generic;

namespace eAppraisal.Domain.Entities;

public partial class ManagerComments
{
    public long CommentId { get; set; }

    public long AppraisalId { get; set; }

    public string? Achievements { get; set; }

    public string? ThingsNotAchieved { get; set; }

    public string? Suggestions { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? AddedBy { get; set; }

    public string? ModifyBy { get; set; }

    public DateTime? AddedAt { get; set; }

    public DateTime? ModifyAt { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual Appraisal Appraisal { get; set; } = null!;
}
