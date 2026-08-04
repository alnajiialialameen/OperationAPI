using System;
using System.Collections.Generic;

namespace OperationAPI.Presistence.Models;

public partial class AspNetUserClaim
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public string? ClaimType { get; set; }

    public string? ClaimValue { get; set; }

    public virtual AspNetUsers1 User { get; set; } = null!;
}
