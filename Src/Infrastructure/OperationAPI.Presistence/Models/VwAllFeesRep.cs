using System;
using System.Collections.Generic;

namespace OperationAPI.Presistence.Models;

public partial class VwAllFeesRep
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTime? LandingDate { get; set; }

    public decimal? LandingFees { get; set; }

    public decimal? ParkingFees { get; set; }

    public decimal? NightOperationFees { get; set; }

    public decimal? NavigationFees { get; set; }

    public decimal? SecurityFees { get; set; }

    public decimal? FreightFees { get; set; }

    public decimal? FirstClassFees { get; set; }

    public decimal? FireFightingFees { get; set; }

    public decimal? AmbolanceFees { get; set; }

    public decimal? InterCuppsfees { get; set; }

    public decimal? DomeCuppsfees { get; set; }

    public decimal? InterNyfees { get; set; }

    public decimal? DomeNyfees { get; set; }

    public decimal? PushBackFees { get; set; }

    public decimal? ExpMailFees { get; set; }

    public decimal? ImpMailFees { get; set; }

    public decimal? NoiseFees { get; set; }

    public decimal? OpenAireportOvertimeFees { get; set; }
}
