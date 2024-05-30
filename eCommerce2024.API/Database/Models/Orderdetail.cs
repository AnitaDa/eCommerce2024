using System;
using System.Collections.Generic;

namespace eCommerce2024.API.Database.Models;

public partial class Orderdetail
{
    public int Id { get; set; }

    public int? OrderId { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public decimal? UnitPrice { get; set; }

    public int? ColorId { get; set; }

    public virtual Color? Color { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }
}
