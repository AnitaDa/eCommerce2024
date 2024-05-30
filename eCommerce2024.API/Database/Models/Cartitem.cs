using eCommerce2024.API.Models;
using System;
using System.Collections.Generic;

namespace eCommerce2024.API.Database.Models;

public partial class Cartitem
{
    public int Id { get; set; }

    public int? CartId { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public decimal? Price { get; set; }

    public virtual Cart? Cart { get; set; }

    public virtual Product? Product { get; set; }
}
