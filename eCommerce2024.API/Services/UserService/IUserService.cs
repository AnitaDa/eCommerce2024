using eCommerce2024.API.Database.Models;
using Microsoft.AspNetCore.Identity;

namespace eCommerce2024.API.Services.UserService
{
    public interface IUserService
    {
        public Task<string> GenerateJWTToken(CustomUser user);
    }
}
