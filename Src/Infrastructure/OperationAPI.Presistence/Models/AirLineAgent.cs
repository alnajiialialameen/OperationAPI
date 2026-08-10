using System;
using System.Collections.Generic;

namespace OperationAPI.Presistence.Models;

public partial class AirLineAgent
{
    public int Id { get; set; }

    public string? NameAr { get; set; }

    public string? NameAn { get; set; }

    public string? Phone1 { get; set; }

    public string? Phone2 { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public int? AirLineId { get; set; }

    public bool IsActive { get; set; }

    public string? UserId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatingDate { get; set; }

    public virtual AirLine? AirLine { get; set; }

    //public virtual AspNetUsers1? User { get; set; }

    public virtual ICollection<AireCraftStyIn> AireCraftStyInAireLineAgentId1Navigations { get; set; } = new List<AireCraftStyIn>();

    public virtual ICollection<AireCraftStyIn> AireCraftStyInAireLineAgentId2Navigations { get; set; } = new List<AireCraftStyIn>();

    public virtual ICollection<OfficerDatum> OfficerData { get; set; } = new List<OfficerDatum>();
}
