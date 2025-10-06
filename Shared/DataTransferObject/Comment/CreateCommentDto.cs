namespace Shared.DataTransferObject.Comment
{
    public class CreateCommentDto
    {
        public string Content { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        // ✅ Optional: Reply
        public int? ParentCommentId { get; set; }
    }
}
