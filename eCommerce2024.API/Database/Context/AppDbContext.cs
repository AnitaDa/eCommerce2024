using eCommerce2024.API.Database.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eCommerce2024.API.Database.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options): IdentityDbContext<CustomUser>(options)
    {
    }
}
