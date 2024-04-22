﻿using System;
using System.Collections.Generic;

namespace eCommerce2024.API.Database;

public partial class Orderitem
{
    public int OrderItemId { get; set; }

    public int? OrderId { get; set; }

    public int? ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal Subtotal { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }
}
