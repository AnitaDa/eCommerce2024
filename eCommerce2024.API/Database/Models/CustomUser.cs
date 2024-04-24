using Microsoft.AspNetCore.Identity;

namespace eCommerce2024.API.Database.Models
{
    public class CustomUser:IdentityUser
    {
        public ICollection<Customer> Customers { get; set; } = null!;
    }
}
