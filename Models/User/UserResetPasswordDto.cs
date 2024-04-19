using System.ComponentModel.DataAnnotations;

namespace Models.User
{
    public class UserResetPasswordDto
    {
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "NewPassword is required.")]
        public string NewPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "ConfirmPassword is required.")]
        [Compare("NewPassword", ErrorMessage = "New password and Confirm password don't match")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "ResetPasswordToken is required.")]
        public string ResetPasswordToken { get; set; } = string.Empty;
    }
}
