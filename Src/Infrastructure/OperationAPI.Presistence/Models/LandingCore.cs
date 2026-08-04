using System;
using System.Collections.Generic;

namespace OperationAPI.Presistence.Models;

public partial class LandingCore
{
    public int Id { get; set; }

    public string? FlightNo { get; set; }

    public DateTime? FlightDate { get; set; }

    public string? CompanyCode { get; set; }

    public string? FlightType { get; set; }

    public string? RegNo { get; set; }

    public string? PlaneSizeId { get; set; }

    public double? Wt { get; set; }

    public DateTime? Ata { get; set; }

    public string? Ata2 { get; set; }

    public DateTime? Atd { get; set; }

    public string? Atd2 { get; set; }

    public string? FlightFrom { get; set; }

    public string? FlightTo { get; set; }

    public double? FreightOut { get; set; }

    public double? FreightIn { get; set; }

    public double? MailIn { get; set; }

    public double? MailOut { get; set; }

    public double? ExpMainIn { get; set; }

    public double? ExpMailOut { get; set; }

    public bool Cargo { get; set; }

    public bool Posted { get; set; }

    public bool NightSurgarche { get; set; }

    public bool TrainingOp { get; set; }

    public DateTime? UpdateTime { get; set; }

    public double? UserId { get; set; }

    public double? DolarRate { get; set; }

    public double? UnitsParking { get; set; }

    public double? LandingFees { get; set; }

    public double? ParkingFees { get; set; }

    public double? NightSurgarcgeFees { get; set; }

    public double? UserChargeFees { get; set; }

    public double? SecurityFees { get; set; }

    public double? FreightFees { get; set; }

    public double? FirstClassFees { get; set; }

    public double? PushBackFees { get; set; }

    public double? ExpressMailFees { get; set; }

    public double? MailFees { get; set; }

    public double? HandlingCode { get; set; }

    public bool NoUserCharge { get; set; }

    public bool PushBack { get; set; }

    public double? NoiceFees { get; set; }

    public bool Scheduled { get; set; }
}
