using System;
using System.Collections.Generic;

namespace OperationAPI.Presistence.Models;

public partial class ServiceRequestDetail
{
    public int Id { get; set; }

    public int? ServiceRequestId { get; set; }

    public int? ServiceTypeId { get; set; }

    public int? CountOfRequests { get; set; }

    public DateTime? RequestedAt { get; set; }

    public string? RequestedBy { get; set; }

    public DateTime? AcceptedAt { get; set; }

    public string? AcceptedBy { get; set; }

    public DateTime? ConfirmAgentAt { get; set; }

    public string? ConfirmAgentBy { get; set; }

    public int? RequestStatus { get; set; }

    public virtual ServiceRequest? ServiceRequest { get; set; }

    public virtual ServiceType? ServiceType { get; set; }
}
