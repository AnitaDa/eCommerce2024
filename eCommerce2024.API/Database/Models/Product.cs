using System;
using System.Collections.Generic;

namespace eCommerce2024.API.Database.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public int? QuantityAvailable { get; set; }

    public int? CategoryId { get; set; }

    public DateOnly? DateAdded { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();
}
