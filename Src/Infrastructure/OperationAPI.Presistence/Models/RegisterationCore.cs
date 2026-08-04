using System;
using System.Collections.Generic;

namespace OperationAPI.Presistence.Models;

public partial class RegisterationCore
{
    public int Id { get; set; }

    public string? CompanyCode { get; set; }

    public string? Reg { get; set; }

    public string? Type { get; set; }

    public double? MaxTakeOff { get; set; }

    public string? PlaneSize { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatingDate { get; set; }
}
