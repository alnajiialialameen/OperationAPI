using System;
using System.Collections.Generic;

namespace OperationAPI.Presistence.Models;

public partial class PlaneRcore
{
    public int Id { get; set; }

    public double? PlaneId { get; set; }

    public string? PlaneName { get; set; }

    public string? Notes { get; set; }

    public double? UpdatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public double? Wt { get; set; }

    public string? PlaneType { get; set; }
}
