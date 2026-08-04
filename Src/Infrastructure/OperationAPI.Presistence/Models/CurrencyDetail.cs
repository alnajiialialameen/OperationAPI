using System;
using System.Collections.Generic;

namespace OperationAPI.Presistence.Models;

public partial class CurrencyDetail
{
    public int Id { get; set; }

    public int? CurrencyId { get; set; }

    public int? MonthWorkOn { get; set; }

    public int? YearWorkOn { get; set; }

    public DateTime? Date { get; set; }

    public decimal? ExchangeRateAgainstPrimaryCurrency { get; set; }

    public bool IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatingDate { get; set; }

    public virtual Currency? Currency { get; set; }
}
