using System;
using System.Collections.Generic;

namespace eCommerce2024.API.Database.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
