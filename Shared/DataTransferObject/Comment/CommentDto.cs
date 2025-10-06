
namespace Shared.DataTransferObject.Comment;

public class CommentDto
{
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }

    public int UserId { get; set; }
    public string? UserName { get; set; }

    public int PostId { get; set; }
    // ✅ Reply Relationship
    public int? ParentCommentId { get; set; }

    // ✅ Nested Replies
    public List<CommentDto>? Replies { get; set; }
}
