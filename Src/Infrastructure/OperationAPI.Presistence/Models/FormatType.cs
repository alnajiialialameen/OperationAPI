using System;
using System.Collections.Generic;

namespace OperationAPI.Presistence.Models;

public partial class FormatType
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<PrintFormat> PrintFormats { get; set; } = new List<PrintFormat>();
}
