using System;
using System.Collections.Generic;

namespace OperationAPI.Presistence.Models;

public partial class AspNetRole
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<AspNetUsers1> Users { get; set; } = new List<AspNetUsers1>();
}
