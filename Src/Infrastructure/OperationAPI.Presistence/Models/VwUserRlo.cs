using System;
using System.Collections.Generic;

namespace OperationAPI.Presistence.Models;

public partial class VwUserRlo
{
    public string UserId { get; set; } = null!;

    public string? Email { get; set; }

    public bool EmailConfirmed { get; set; }

    public string? PasswordHash { get; set; }

    public string UserName { get; set; } = null!;

    public int? CompanyInfoId { get; set; }

    public string RoleName { get; set; } = null!;
}
