using Shared.DataTransferObject.Post;

namespace Shared.DataTransferObject.User
{
    public class UserProfileDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string? FullName { get; set; }
        public string? Bio { get; set; }
        public string? ProfileImageUrl { get; set; }
        public int PostsCount { get; set; }
        public int FriendsCount { get; set; }
        public int LikesReceived { get; set; }
        public DateTime JoinedAt { get; set; }

        public IEnumerable<PostDto>? RecentPosts { get; set; }
    }
}
