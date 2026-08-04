using System;
using System.Collections.Generic;

namespace OperationAPI.Presistence.Models;

public partial class VwAllAirlinesSumationFee
{
    public string? Name { get; set; }

    public int? CurrencyType { get; set; }

    public int? AirLineId { get; set; }

    public DateTime? LandingDate { get; set; }

    public int? CompanyInfoId { get; set; }

    public bool IsCurrentAccount { get; set; }

    public bool IsClaimCalculated { get; set; }

    public decimal LandingFees { get; set; }

    public decimal ParkingFees { get; set; }

    public decimal NightOperationFees { get; set; }

    public decimal NavigationFees { get; set; }

    public decimal SecurityFees { get; set; }

    public decimal NoiseFees { get; set; }

    public decimal InterCuppsfees { get; set; }

    public decimal InterNyfees { get; set; }

    public decimal DomeCuppsfees { get; set; }

    public decimal DomeNyfees { get; set; }

    public decimal AmbolanceFees { get; set; }

    public decimal FireFightingFees { get; set; }

    public decimal FreightFees { get; set; }

    public decimal ExpMailFees { get; set; }

    public decimal ImpMailFees { get; set; }

    public decimal FirstClassFees { get; set; }

    public decimal PushBackFees { get; set; }

    public decimal? TotalFees { get; set; }

    public decimal? RevenueStamp { get; set; }
}
