using System;
using System.Collections.Generic;

namespace OperationAPI.Presistence.Models;

public partial class AspNetUserLogin
{
    public string LoginProvider { get; set; } = null!;

    public string ProviderKey { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public virtual AspNetUsers1 User { get; set; } = null!;
}
