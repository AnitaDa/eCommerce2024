using System;
using System.Collections.Generic;

namespace eCommerce2024.API.Database.Models;

public partial class Color
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
