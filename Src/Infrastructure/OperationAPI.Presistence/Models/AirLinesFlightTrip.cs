using System;
using System.Collections.Generic;

namespace OperationAPI.Presistence.Models;

public partial class AirLinesFlightTrip
{
    public int Id { get; set; }

    public string? FlightNo { get; set; }

    public int? AirPortId { get; set; }

    public int? AirLineId { get; set; }

    public bool IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatingDate { get; set; }

    public virtual AirLine? AirLine { get; set; }

    public virtual AirPort? AirPort { get; set; }

    public virtual ICollection<TowerDatum> TowerData { get; set; } = new List<TowerDatum>();
}
