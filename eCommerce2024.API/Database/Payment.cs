using System;
using System.Collections.Generic;

namespace eCommerce2024.API.Database;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int? OrderId { get; set; }

    public decimal Amount { get; set; }

    public DateTime? PaymentDate { get; set; }

    public string? PaymentMethod { get; set; }

    public string? TransactionId { get; set; }

    public string? PaymentStatus { get; set; }

    public virtual Order? Order { get; set; }
}
