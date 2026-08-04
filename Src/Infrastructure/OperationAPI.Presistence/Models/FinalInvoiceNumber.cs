using System;
using System.Collections.Generic;

namespace OperationAPI.Presistence.Models;

public partial class FinalInvoiceNumber
{
    public int Id { get; set; }

    public int? AirLineId { get; set; }

    public int? Month { get; set; }

    public int? Year { get; set; }

    public int? InvoiceNo { get; set; }

    public bool IsFinal { get; set; }

    public string? CreatedBy { get; set; }

    public string? CreationDate { get; set; }

    public string? UpdatedBy { get; set; }

    public string? UpdationDate { get; set; }

    public virtual AirLine? AirLine { get; set; }
}
