using OperationAPI.Presistence.PartialModel;
using System;
using System.Collections.Generic;

namespace OperationAPI.Presistence.Models;

public partial class AircraftRegistration
{
    public int Id { get; set; }

    public string Registration { get; set; } = null!;

    public int? AircraftTypeId { get; set; }

    public decimal? MaxTakoffWieght { get; set; }

    public int? AireLineId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatingDate { get; set; }

    public virtual AircraftType? AircraftType { get; set; }

    public virtual ICollection<AireCraftStyIn> AireCraftStyIns { get; set; } = new List<AireCraftStyIn>();

    public virtual AirLine? AireLine { get; set; }

    public virtual ICollection<TowerDatum> TowerData { get; set; } = new List<TowerDatum>();
}
