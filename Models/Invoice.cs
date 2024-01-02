using System;
using System.Collections.Generic;

namespace IdioAPI.Models;

public partial class Invoice
{
    public int Id { get; set; }

    public string Customer { get; set; } = null!;

    public int? Status { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? Timestamp { get; set; }
}
