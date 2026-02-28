using System;
using System.Collections.Generic;

namespace eAppraisal.Domain.Entities;

public partial class AppraisalStatusMaster
{
    public long StatusId { get; set; }

    public string? StatusName { get; set; }

    public string? Description { get; set; }

    public string? AddedBy { get; set; }

    public string? ModifyBy { get; set; }

    public DateTime? AddedAt { get; set; }

    public DateTime? ModifyAt { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<Appraisal> Appraisals { get; set; } = new List<Appraisal>();
}
