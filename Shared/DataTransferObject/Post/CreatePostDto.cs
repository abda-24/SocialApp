namespace Shared.DataTransferObject.Post
{
    public class CreatePostDto
    {
        public string? Content { get; set; }
        public string? ImageUrl { get; set; }
        public int UserId { get; set; }
    }
}
