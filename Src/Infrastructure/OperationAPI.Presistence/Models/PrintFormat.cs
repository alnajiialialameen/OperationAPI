using System;
using System.Collections.Generic;

namespace OperationAPI.Presistence.Models;

public partial class PrintFormat
{
    public int Id { get; set; }

    public int? FormatTypeId { get; set; }

    public virtual FormatType? FormatType { get; set; }
}
