using System;
using System.Collections.Generic;

namespace IdioAPI.Models;

public partial class InvoiceTransactionLog
{
    public long Id { get; set; }

    public int InvoiceId { get; set; }

    public int Status { get; set; }

    public decimal Amount { get; set; }

    public DateTime Timestamp { get; set; }
}
