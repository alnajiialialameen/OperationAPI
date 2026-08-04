using System;
using System.Collections.Generic;

namespace OperationAPI.Presistence.Models;

public partial class WorkOn
{
    public int Id { get; set; }

    public string? UserId { get; set; }

    public int? YearWorkOn { get; set; }

    public int? MonthWorkOn { get; set; }

    public int? CompanyInfoId { get; set; }

    public virtual CompanyInfo? CompanyInfo { get; set; }
}
