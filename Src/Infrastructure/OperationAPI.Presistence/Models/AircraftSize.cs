using System;
using System.Collections.Generic;

namespace OperationAPI.Presistence.Models;

public partial class AircraftSize
{
    public int Id { get; set; }

    public string? Size { get; set; }

    public virtual ICollection<AircraftType> AircraftTypes { get; set; } = new List<AircraftType>();
}
