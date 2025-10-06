using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject.User
{
    public class ResetPasswordDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Token { get; set; } // The OTP/Reset Token

        [Required]
        [MinLength(6)]
        public string NewPassword { get; set; }
    }
}
