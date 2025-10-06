using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User:BaseEntity<int>
    {

        public string Username { get; set; }
        public string Email { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? Bio { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Like> Likes { get; set; } = new List<Like>();
        public ICollection<Friendship> SentFriendRequests { get; set; } = new List<Friendship>();
        public ICollection<Friendship> ReceivedFriendRequests { get; set; } = new List<Friendship>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
        public ICollection<Conversation> Conversations { get; set; } = new List<Conversation>();

    }

}

