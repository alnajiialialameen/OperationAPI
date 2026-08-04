using System;
using System.Collections.Generic;

namespace OperationAPI.Presistence.Models;

public partial class Revenue
{
    public int Id { get; set; }

    public int? OfficerDataId { get; set; }

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

    public decimal? FuelFees { get; set; }

    public decimal? GroundHandlingFees { get; set; }

    public int? CompanyInfoId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatingDate { get; set; }

    public decimal? ExchangeRate { get; set; }

    public virtual CompanyInfo? CompanyInfo { get; set; }

    public virtual OfficerDatum? OfficerData { get; set; }
}
