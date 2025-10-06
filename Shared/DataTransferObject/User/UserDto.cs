using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string? Bio { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
