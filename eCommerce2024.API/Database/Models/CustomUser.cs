using Microsoft.AspNetCore.Identity;

namespace eCommerce2024.API.Database.Models
{
    public class CustomUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public List<Order>? Orders { get; set; }
    }
}
