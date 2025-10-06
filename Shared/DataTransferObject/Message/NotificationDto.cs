using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject.Message
{
    public class NotificationDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
        public int RecipientId { get; set; }
    }
}
