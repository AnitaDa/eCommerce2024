using eCommerce2024.API.Database.Models;
using eCommerce2024.API.Enums;
using eCommerce2024.API.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.User;
using System.Security.Claims;

namespace eCommerce2024.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserService _userService;
        public UserController(
            UserManager<CustomUser> userManager,
            SignInManager<CustomUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IUserService userService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userService = userService;
            _roleManager = roleManager;
        }

        [HttpPost]
        public async Task<ActionResult> Login(UserLoginDto loginUser)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginUser.Email);
                if (user is not null)
                {
                    var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, loginUser.Password);
                    if (isPasswordCorrect)
                    {
                        var isEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);
                        if(isEmailConfirmed)
                        {
                            var token = await _userService.GenerateJWTToken(user);
                            return Ok(token);
                        }
                        else
                        {
                            return BadRequest("User doesn't exist");
                        }
                    }
                    else
                    {
                        return BadRequest("Email or Password is not correct.");
                    }

                }
            }
            return BadRequest();
        }
        [HttpPost]
        public async Task<ActionResult> Register(UserRegistrationDto newUser)
        {
            if (ModelState.IsValid)
            {
                var user = new CustomUser
                {
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    UserName = newUser.UserName,
                    Email = newUser.EmailAddress,
                    Street = newUser.Street,
                    City = newUser.City,
                    Country = newUser.Country,
                    PhoneNumber = newUser.PhoneNumber,
                    DateOfBirth = newUser.DateOfBirth
                };
                var doesUserExist = await _userManager.FindByEmailAsync(user.Email);
                if (doesUserExist is null) {
                    var createdUser = await _userManager.CreateAsync(user);
                    if (createdUser.Succeeded)
                    {
                        await _userManager.AddPasswordAsync(user, newUser.Password);
                        await _userManager.AddToRoleAsync(user, "User");
                        return Ok(UserStatusResponse.UserIsCreated);
                    }
                    else
                    {
                        if(createdUser.Errors.Count() > 0)
                        {
                            foreach(var err in createdUser.Errors)
                            {
                                ModelState.AddModelError("Error", err.Description);
                            }
                        }
                        return BadRequest(ModelState);
                    }
                }
                else
                {
                    return BadRequest(UserStatusResponse.UserAlreadyExist);
                }
            }
            
            return BadRequest(UserStatusResponse.UserIsNotCreated);
        }
        [HttpPost]
        public async Task<bool> AddRole(string roleName)
        {
            var result = await _roleManager.CreateAsync(new IdentityRole { Name = roleName });
            if(result.Succeeded)
              return true;
            return false;
        }
        [HttpPost]
        public async Task<bool> ConfirmEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if(user is not null)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if(result.Succeeded)
                    return true;
            }
            return false;
        }
        [HttpPost]
        public async Task<ActionResult> ChangePassword(UserChangePasswordDto changePassword)
        {
            var emailCurrentLoggedUser = HttpContext.User.Claims.SingleOrDefault(p=>p.Type == ClaimTypes.Email)?.Value.ToString();
            if (emailCurrentLoggedUser is not null)
            {
                var currentUser = await _userManager.FindByEmailAsync(emailCurrentLoggedUser);
                if (ModelState.IsValid && currentUser is not null)
                {
                    var result = await _userManager.ChangePasswordAsync(currentUser, changePassword.OldPassword, changePassword.NewPassword);
                    if (result.Succeeded)
                        return Ok();
                }
            }
            return BadRequest();
        }
        [HttpPost]
        public async Task<ActionResult> GeneratePasswordResetToken(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if(user is not null)
            {
                var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                
                return Ok(resetToken);
            }
            return BadRequest();
        }
        [HttpPost]
        public async Task<ActionResult> ResetPassword(UserResetPasswordDto credentials)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(credentials.Email);
                var result = await _userManager.ResetPasswordAsync(user, credentials.ResetPasswordToken, credentials.NewPassword);
                if(result.Succeeded)
                   return Ok();
            }
            return BadRequest();
        }
    }
}
