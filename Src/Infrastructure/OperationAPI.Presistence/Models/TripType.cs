using System;
using System.Collections.Generic;

namespace OperationAPI.Presistence.Models;

public partial class TripType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatingDate { get; set; }

    public virtual ICollection<TowerDatum> TowerData { get; set; } = new List<TowerDatum>();
}
