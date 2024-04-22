using System;
using System.Collections.Generic;

namespace eCommerce2024.API.Database.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public string Category { get; set; } = null!;

    public int StockQuantity { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<Orderitem> Orderitems { get; set; } = new List<Orderitem>();
}
