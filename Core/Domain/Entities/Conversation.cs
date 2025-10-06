using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Conversation:BaseEntity<int>
    {
        // Models/Conversation.cs

          
            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

            public ICollection<User> Participants { get; set; } = new List<User>();

            public ICollection<Message> Messages { get; set; } = new List<Message>();
        }

    }

