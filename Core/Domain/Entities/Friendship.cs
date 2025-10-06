using Domain.Common;
using Domain.Entities;

public class Friendship:BaseEntity<int>
{

  
        public int Id { get; set; }
        public DateTime RequestedAt { get; set; } = DateTime.UtcNow;
        public DateTime? RespondedAt { get; set; }
        public FriendshipStatus Status { get; set; }

        public int RequesterId { get; set; }
        public User Requester { get; set; }

        public int ReceiverId { get; set; }
        public User Receiver { get; set; }
    }

