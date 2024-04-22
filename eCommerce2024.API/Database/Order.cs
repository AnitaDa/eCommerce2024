using System;
using System.Collections.Generic;

namespace eCommerce2024.API.Database;

public partial class Order
{
    public int OrderId { get; set; }

    public string UserId { get; set; } = null!;

    public DateTime? OrderDate { get; set; }

    public string? ShippingAddress { get; set; }

    public decimal TotalAmount { get; set; }

    public string? OrderStatus { get; set; }

    public string? PaymentStatus { get; set; }

    public virtual ICollection<Orderitem> Orderitems { get; set; } = new List<Orderitem>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Aspnetuser User { get; set; } = null!;
}
