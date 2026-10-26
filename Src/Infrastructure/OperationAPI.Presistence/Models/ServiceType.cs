using System;
using System.Collections.Generic;

namespace OperationAPI.Presistence.Models;

public partial class ServiceType
{
    public int Id { get; set; }

    public string? NameAr { get; set; }

    public string? NameEn { get; set; }

    public bool? IsActive { get; set; }

    public string? LogoCode { get; set; }

    public virtual ICollection<ServiceRequestDetail> ServiceRequestDetails { get; set; } = new List<ServiceRequestDetail>();
}
