
using eCommerce2024.API.Models;

namespace eCommerce2024.API.Database.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string? UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public string? PostalCode { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Paymentmethod> Paymentmethods { get; set; } = new List<Paymentmethod>();

    public virtual CustomUser? User { get; set; }
}
