using System;
using System.Collections.Generic;

namespace OperationAPI.Presistence.Models;

public partial class ServiceRequest
{
    public int Id { get; set; }

    public int? TowerDataId { get; set; }

    public int? AirlineId { get; set; }

    public virtual AirLine? Airline { get; set; }

    public virtual ICollection<ServiceRequestDetail> ServiceRequestDetails { get; set; } = new List<ServiceRequestDetail>();

    public virtual TowerDatum? TowerData { get; set; }
}
