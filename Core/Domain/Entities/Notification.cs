using Domain.Common;

namespace Domain.Entities
{
    public class Notification:BaseEntity<int>
    {

            public NotificationType Type { get; set; }
            public bool IsRead { get; set; } = false;
            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
            public int? SourceId { get; set; }

            public int RecipientId { get; set; }
            public User Recipient { get; set; }

            public int? TriggeredByUserId { get; set; }
            public User? TriggeredByUser { get; set; }
        }

    }




