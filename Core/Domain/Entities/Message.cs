using Domain.Common;
using Microsoft.VisualBasic;

namespace Domain.Entities
{
    public class Message:BaseEntity<int>
    {
        // Models/Message.cs

     
            public int Id { get; set; }
            public string Content { get; set; }
            public DateTime SentAt { get; set; } = DateTime.UtcNow;
            public bool IsRead { get; set; } = false;
            public DateTime? ReadAt { get; set; }

            public int SenderId { get; set; }
            public User Sender { get; set; }

            public int ConversationId { get; set; }
            public Conversation Conversation { get; set; }
        }

    }
