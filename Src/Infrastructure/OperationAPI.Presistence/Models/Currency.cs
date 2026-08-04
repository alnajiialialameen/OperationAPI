using System;
using System.Collections.Generic;

namespace OperationAPI.Presistence.Models;

public partial class Currency
{
    public int Id { get; set; }

    public string? CurrencyName { get; set; }

    public bool? IsActive { get; set; }

    public string? MajorUnit { get; set; }

    public string? MinorUnit { get; set; }

    public decimal? ExchangeRateAgainstPrimaryCurrency { get; set; }

    public string? Notes { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatingDate { get; set; }

    public virtual ICollection<CurrencyDetail> CurrencyDetails { get; set; } = new List<CurrencyDetail>();

    public virtual ICollection<FuelCompany> FuelCompanies { get; set; } = new List<FuelCompany>();

    public virtual ICollection<HandlingAgentsCompany> HandlingAgentsCompanies { get; set; } = new List<HandlingAgentsCompany>();
}
