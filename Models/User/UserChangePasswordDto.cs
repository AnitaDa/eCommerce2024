using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.User
{
    public class UserChangePasswordDto
    {
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Old password is required!")]
        public string OldPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "New password is required!")]
        public string NewPassword { get; set; } = string.Empty;

        [Required(ErrorMessage ="Confirm password is required!")]
        [Compare("NewPassword", ErrorMessage = "New password and Confirm password don't match")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
