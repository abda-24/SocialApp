// Shared/DataTransferObjects/PostDto.cs

// Shared/DataTransferObjects/PostDto.cs
using Shared.DataTransferObject.User;

namespace Shared.DataTransferObject.Post;

public class PostDto
{
    public int Id { get; set; }
    public string? Content { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime CreatedAt { get; set; }

    public UserDto Author { get; set; }

    public int LikesCount { get; set; }
    public int CommentsCount { get; set; }
}
