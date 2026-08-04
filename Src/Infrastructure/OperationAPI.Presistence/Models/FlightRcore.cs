using System;
using System.Collections.Generic;

namespace OperationAPI.Presistence.Models;

public partial class FlightRcore
{
    public int Id { get; set; }

    public string? Acc4Name { get; set; }

    public double? FlightNo { get; set; }

    public string? FlightName { get; set; }

    public string? Destination { get; set; }

    public string? IsDomistic { get; set; }
}
