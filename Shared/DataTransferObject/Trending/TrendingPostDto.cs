namespace Shared.DataTransferObject.Trending
{
    public class TrendingPostDto
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public string? ImageUrl { get; set; }
        public int LikesCount { get; set; }
        public int CommentsCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string AuthorName { get; set; }
        public string AuthorImage { get; set; }
    }
}
