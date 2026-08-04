using System;
using System.Collections.Generic;

namespace OperationAPI.Presistence.Models;

public partial class ViewFlightNoInsert
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? CompanyCode { get; set; }

    public string? FlightNo { get; set; }

    public string? FlightTo { get; set; }
}
