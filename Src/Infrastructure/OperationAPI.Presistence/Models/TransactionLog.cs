using System;
using System.Collections.Generic;

namespace OperationAPI.Presistence.Models;

public partial class TransactionLog
{
    public int Id { get; set; }

    public int? TowerDataId { get; set; }

    public int? OfficerDataId { get; set; }

    public int? RevenueDataId { get; set; }

    public bool? IsComplate { get; set; }
}
