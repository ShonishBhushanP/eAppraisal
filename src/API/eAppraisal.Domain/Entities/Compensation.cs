using System;
using System.Collections.Generic;

namespace eAppraisal.Domain.Entities;

public partial class Compensation
{
    public long CompensationId { get; set; }

    public long AppraisalId { get; set; }

    public decimal? BasicSalary { get; set; }

    public decimal? DearnessAllowance { get; set; }

    public decimal? HouseRentAllowance { get; set; }

    public decimal? FoodAllowance { get; set; }

    public decimal? ProvidentFund { get; set; }

    public bool? Promoted { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? AddedBy { get; set; }

    public string? ModifyBy { get; set; }

    public DateTime? AddedAt { get; set; }

    public DateTime? ModifyAt { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual Appraisal Appraisal { get; set; } = null!;
}
