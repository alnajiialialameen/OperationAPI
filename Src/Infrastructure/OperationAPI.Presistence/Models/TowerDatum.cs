using System;
using System.Collections.Generic;

namespace OperationAPI.Presistence.Models;

public partial class TowerDatum
{
    public int Id { get; set; }

    public int? AirLineId { get; set; }

    public int? FlightNo { get; set; }

    public int? AircraftRegId { get; set; }

    public int? AirportIdFrom { get; set; }

    public int? AirportIdTo { get; set; }

    public int? FlightTypeD { get; set; }

    public int? FlightTypeL { get; set; }

    public DateTime? LandingDate { get; set; }

    public DateTime? TakeOffDate { get; set; }

    public int? Status { get; set; }

    public DateOnly? Date { get; set; }

    public TimeOnly? Ata { get; set; }

    public TimeOnly? Atd { get; set; }

    public int? Pob { get; set; }

    public int? Qbd { get; set; }

    public int? TripTypeId { get; set; }

    public string? LandingPermission { get; set; }

    public int? CompanyInfoId { get; set; }

    public string? Note { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatingDate { get; set; }

    public virtual AirLine? AirLine { get; set; }

    public virtual AircraftRegistration? AircraftReg { get; set; }

    public virtual AirPort? AirportIdFromNavigation { get; set; }

    public virtual AirPort? AirportIdToNavigation { get; set; }

    public virtual CompanyInfo? CompanyInfo { get; set; }

    public virtual AirLinesFlightTrip? FlightNoNavigation { get; set; }

    public virtual ICollection<OfficerDatum> OfficerData { get; set; } = new List<OfficerDatum>();

    public virtual TripType? TripType { get; set; }
}
