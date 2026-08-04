using System;
using System.Collections.Generic;

namespace OperationAPI.Presistence.Models;

public partial class AireCraftStyIn
{
    public int Id { get; set; }

    public int? AireLineId { get; set; }

    public int? AireCraftRegId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? AireLineAgentId1 { get; set; }

    public int? AireLineAgentId2 { get; set; }

    public bool IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatingDate { get; set; }

    public virtual AircraftRegistration? AireCraftReg { get; set; }

    public virtual ICollection<AireCraftStyInFee> AireCraftStyInFees { get; set; } = new List<AireCraftStyInFee>();

    public virtual AirLine? AireLine { get; set; }

    public virtual AirLineAgent? AireLineAgentId1Navigation { get; set; }

    public virtual AirLineAgent? AireLineAgentId2Navigation { get; set; }
}
