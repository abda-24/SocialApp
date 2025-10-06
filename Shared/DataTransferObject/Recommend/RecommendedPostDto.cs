namespace Shared.DataTransferObject.Recommend
{
    public class RecommendedPostDto
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }

       
        public int AuthorId { get; set; }
        public string? AuthorName { get; set; }
        public string? AuthorProfileImage { get; set; }

       
        public int LikesCount { get; set; }
        public int CommentsCount { get; set; }

        
        public string? Reason { get; set; }
    }
}
