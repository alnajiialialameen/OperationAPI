using System;
using System.Collections.Generic;

namespace OperationAPI.Presistence.Models;

public partial class HandlingAgentsCompany
{
    public int Id { get; set; }

    public int? AccId { get; set; }

    public int? CurrencyId { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? NameAr { get; set; }

    public string? NameEn { get; set; }

    public string? Address { get; set; }

    public bool IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatingDate { get; set; }

    public virtual Currency? Currency { get; set; }

    public virtual ICollection<OfficerDatum> OfficerData { get; set; } = new List<OfficerDatum>();
}
