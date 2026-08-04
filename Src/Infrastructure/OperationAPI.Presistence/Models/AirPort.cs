using System;
using System.Collections.Generic;

namespace OperationAPI.Presistence.Models;

public partial class AirPort
{
    public int Id { get; set; }

    public string? NameAr { get; set; }

    public string? NameEn { get; set; }

    public string? Code { get; set; }

    public int? CountryId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatingDate { get; set; }

    public string? Destination { get; set; }

    public virtual ICollection<AirLinesFlightTrip> AirLinesFlightTrips { get; set; } = new List<AirLinesFlightTrip>();

    public virtual Country? Country { get; set; }

    public virtual ICollection<TowerDatum> TowerDatumAirportIdFromNavigations { get; set; } = new List<TowerDatum>();

    public virtual ICollection<TowerDatum> TowerDatumAirportIdToNavigations { get; set; } = new List<TowerDatum>();
}
