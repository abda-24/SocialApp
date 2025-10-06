using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject.User
{
    public class ForgotPasswordRequestDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
