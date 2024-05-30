using eCommerce2024.API.Database.Models;
using System;
using System.Collections.Generic;

namespace eCommerce2024.API.Models;

public partial class Cart
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual ICollection<Cartitem> Cartitems { get; set; } = new List<Cartitem>();

    public virtual Customer? Customer { get; set; }
}
