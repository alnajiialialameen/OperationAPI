using System;
using System.Collections.Generic;

namespace OperationAPI.Presistence.Models;

public partial class VwJournalCuppsdome
{
    public DateOnly? Date { get; set; }

    public decimal? Total { get; set; }

    public int Id { get; set; }
}
