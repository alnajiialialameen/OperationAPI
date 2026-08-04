using System;
using System.Collections.Generic;

namespace OperationAPI.Presistence.Models;

public partial class AirLine
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? ArName { get; set; }

    public string? Address { get; set; }

    public int? AccId { get; set; }

    public bool IsLocalCompany { get; set; }

    public int? CurrencyType { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatingDate { get; set; }

    public virtual ICollection<AirLineAgent> AirLineAgents { get; set; } = new List<AirLineAgent>();

    public virtual ICollection<AirLinesFlightTrip> AirLinesFlightTrips { get; set; } = new List<AirLinesFlightTrip>();

    public virtual ICollection<AircraftRegistration> AircraftRegistrations { get; set; } = new List<AircraftRegistration>();

    public virtual ICollection<AireCraftStyIn> AireCraftStyIns { get; set; } = new List<AireCraftStyIn>();

    public virtual ICollection<FinalInvoiceNumber> FinalInvoiceNumbers { get; set; } = new List<FinalInvoiceNumber>();

    public virtual ICollection<TowerDatum> TowerData { get; set; } = new List<TowerDatum>();
}
