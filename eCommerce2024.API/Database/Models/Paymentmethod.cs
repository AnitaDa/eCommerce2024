using System;
using System.Collections.Generic;

namespace eCommerce2024.API.Database.Models;

public partial class Paymentmethod
{
    public int PaymentMethodId { get; set; }

    public int? CustomerId { get; set; }

    public string? MethodType { get; set; }

    public string? CardNumber { get; set; }

    public DateOnly? ExpirationDate { get; set; }

    public string? Cvv { get; set; }

    public virtual Customer? Customer { get; set; }
}
