namespace Shared.DataTransferObject.Feed
{
    public class FeedPostDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }

      
        public int AuthorId { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public string? AuthorProfileImage { get; set; }

       
        public int LikesCount { get; set; }
        public int CommentsCount { get; set; }
    }
}
