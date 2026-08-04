using System;
using System.Collections.Generic;

namespace OperationAPI.Presistence.Models;

public partial class VwAllPax
{
    public string? Name { get; set; }

    public int? Month { get; set; }

    public int? Year { get; set; }

    public int? TotalPax { get; set; }
}
