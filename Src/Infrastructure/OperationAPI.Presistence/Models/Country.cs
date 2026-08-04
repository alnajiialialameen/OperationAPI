using System;
using System.Collections.Generic;

namespace OperationAPI.Presistence.Models;

public partial class Country
{
    public int Id { get; set; }

    public string? NameAr { get; set; }

    public string? NameEn { get; set; }

    public string? Code { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpadatingDate { get; set; }

    public virtual ICollection<AirPort> AirPorts { get; set; } = new List<AirPort>();
}
