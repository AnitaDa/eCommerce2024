using eCommerce2024.API.Database.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eCommerce2024.API.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        protected readonly UserManager<CustomUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;
        
        public UserService(
            IConfiguration configuration,
            UserManager<CustomUser> userManager,
            IHttpContextAccessor httpContextAccessor) {
            _configuration = configuration;
            _userManager = userManager;
            _contextAccessor = httpContextAccessor;
        }
        public async Task<string> GenerateJWTToken(CustomUser user)
        {
            var claims = new List<Claim> {
             new Claim(ClaimTypes.Name, user.UserName),
             new Claim(ClaimTypes.Email, user.Email),
             new Claim(ClaimTypes.NameIdentifier, user.Id)
            };
            var userRoles = await _userManager.GetRolesAsync(user);
            foreach(var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = Encoding.ASCII.GetBytes(_configuration["AuthSettings:Key"]);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["AuthSettings:Iss"],
                Audience = _configuration["AuthSettings:Aud"],
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string? GetCurrentLoggedUser()
        {
            string userId = null;
            var httpContext = _contextAccessor.HttpContext;
            var user = httpContext?.User;
            if(user is not null && user.Identity is not null && user.Identity.IsAuthenticated)
            {
                userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            return userId;
        }
    }
}
