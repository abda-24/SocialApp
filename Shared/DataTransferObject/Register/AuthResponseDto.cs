using Shared.DataTransferObject.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject.Register
{
    public class AuthResponseDto
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public string? Token { get; set; }
    }
}
