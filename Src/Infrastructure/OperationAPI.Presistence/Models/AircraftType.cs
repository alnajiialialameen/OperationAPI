using System;
using System.Collections.Generic;

namespace OperationAPI.Presistence.Models;

public partial class AircraftType
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public int? SizeId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatingDate { get; set; }

    public virtual ICollection<AircraftRegistration> AircraftRegistrations { get; set; } = new List<AircraftRegistration>();

    public virtual AircraftSize? Size { get; set; }
}
