using System;
using System.Collections.Generic;

namespace OperationAPI.Presistence.Models;

public partial class AireCraftStyInFee
{
    public int Id { get; set; }

    public int? StayInId { get; set; }

    public DateTime? AccountingDate { get; set; }

    public int? Year { get; set; }

    public int? Month { get; set; }

    public decimal? SettingAmount { get; set; }

    public decimal? TotalAmount { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatingDate { get; set; }

    public virtual AireCraftStyIn? StayIn { get; set; }
}
